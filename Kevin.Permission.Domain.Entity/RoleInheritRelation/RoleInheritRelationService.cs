using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;
using Kevin.Infrastructure.Domain.Specification;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;
    using Kevin.Permission.Infrastructure;

    /// <summary>
    /// 角色继承关联数据仓库类
    /// </summary>
    public class RoleInheritRelationService : IRoleInheritRelationService
    {
        #region Members

        /// <summary>
        /// Entity统一工作单元接口实例对象
        /// </summary>
        protected IEntityUnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色继承关联数据源
        /// </summary>
        private IDbSet<RoleInheritRelation> RoleInheritRelations
        {
            get
            {
                return UnitOfWork.DbSet<RoleInheritRelation>();
            }
        }

        #endregion

        #region Constructor

        public RoleInheritRelationService(IEntityUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取角色继承关联对象
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="inheritRole">继承的角色</param>
        /// <returns>角色继承关联对象</returns>
        private RoleInheritRelation Get(Role role, Role inheritRole)
        {
            var relation = RoleInheritRelations
                .FirstOrDefault(ri =>
                    ri.Role.Id == role.Id
                    &&
                    ri.InheritRole.Id == inheritRole.Id);
            return relation;
        }

        /// <summary>
        /// 判断角色是否继承给定的角色，默认进行级联的查询
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="inheritRole">继承的角色</param>
        /// <returns>是有有继承关系</returns>
        private bool HaveInheritRelation(Role role, Role inheritRole)
        {
            var inheritRoles = GetInheritRolesOfRole(role, true);
            return inheritRoles.Contains(inheritRole);
        }

        /// <summary>
        /// 判断角色是否继承其他角色
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns>是否继承其他的角色</returns>
        private bool HaveInheritRoles(Role role)
        {
            var result = RoleInheritRelations
                .Any(ri => ri.Role.Id == role.Id);
            return result;
        }

        #endregion

        #region IUserRoleRelationRepository implementation

        /// <summary>
        /// <see cref="IRoleInheritRelationService"/>
        /// </summary>
        /// <param name="role"><see cref="IRoleInheritRelationService"/></param>
        /// <param name="inheritRole"><see cref="IRoleInheritRelationService"/></param>
        public void AddRelation(Role role, Role inheritRole)
        {
            Guidance.ArgumentNotNull(role, "role");
            Guidance.ArgumentNotNull(inheritRole, "inheritRole");

            //角色不能继承角色本身
            if (role == inheritRole)
            {
                throw new InvalidOperationException(
                    Resource.Messages.exception_ShouldNotSelfInherit);
            }
            //角色类型验证
            if (role.Category.InheritType == (int)RoleInheritType.NotInherit)
            {
                throw new InvalidOperationException(
                    Resource.Messages.exception_NotEnableInherit);
            }
            //角色与继承的角色的角色类型必须相同
            if (role.Category != inheritRole.Category)
            {
                throw new InvalidOperationException(
                    Resource.Messages.exception_RoleCateogyShouldSame);
            }
            //避免角色的循环继承
            if (HaveInheritRelation(inheritRole, role))
            {
                throw new InvalidOperationException(
                    Resource.Messages.exception_CycleInherit);
            }
            //角色类型为单继承时唯一性验证
            if (role.Category.InheritType == (int)RoleInheritType.SingleInherit)
            {
                if (HaveInheritRoles(role))
                {
                    throw new InvalidOperationException(
                        Resource.Messages.exception_RoleShouldSingleInherit);
                }
            }

            var relation = new RoleInheritRelation(role, inheritRole);
            UnitOfWork.RegisterNew<RoleInheritRelation, int>(relation);
        }

        /// <summary>
        /// <see cref="IRoleInheritRelationService"/>
        /// </summary>
        /// <param name="role"><see cref="IRoleInheritRelationService"/></param>
        /// <param name="inheritRole"><see cref="IRoleInheritRelationService"/></param>
        public void RemoveRelation(Role role, Role inheritRole)
        {
            Guidance.ArgumentNotNull(role, "role");
            Guidance.ArgumentNotNull(inheritRole, "inheritRole");

            var relation = Get(role, inheritRole);
            if (relation == null)
            {
                throw new InvalidOperationException(
                    Resource.Messages.exception_NotInheritTheRole);
            }
            UnitOfWork.RegisterRemove<RoleInheritRelation, int>(relation);
        }

        /// <summary>
        /// <see cref="IRoleInheritRelationService"/>
        /// </summary>
        /// <param name="role"><see cref="IRoleInheritRelationService"/></param>
        /// <param name="cascade"><see cref="IRoleInheritRelationService"/></param>
        /// <returns><see cref="IRoleInheritRelationService"/></returns>
        public IEnumerable<Role> GetInheritRolesOfRole(Role role, bool cascade)
        {
            Guidance.ArgumentNotNull(role, "role");

            var result = new List<Role>();
            if (role.Category.InheritType != (int)RoleInheritType.NotInherit)
            {
                IEnumerable<Role> roles = RoleInheritRelations
                    .Where(ri => ri.Role.Id == role.Id)
                    .Select(ri => ri.InheritRole)
                    .ToArray();
                result.AddRange(roles);

                if (cascade
                    &&
                    roles.Any())
                {
                    roles = GetInheritRolesOfRoles(roles);
                    result.AddRange(roles);
                }
            }
            return result;
        }

        /// <summary>
        /// <see cref="IRoleInheritRelationService"/>
        /// </summary>
        /// <param name="role"><see cref="IRoleInheritRelationService"/></param>
        /// <param name="cascade"><see cref="IRoleInheritRelationService"/></param>
        /// <returns><see cref="IRoleInheritRelationService"/></returns>
        public IEnumerable<Role> GetDeriveRolesOfRole(Role role, bool cascade)
        {
            Guidance.ArgumentNotNull(role, "role");

            var result = new List<Role>();
            if (role.Category.InheritType != (int)RoleInheritType.NotInherit)
            {
                IEnumerable<Role> roles = RoleInheritRelations
                    .Where(ri => ri.InheritRole.Id == role.Id)
                    .Select(ri => ri.Role)
                    .ToArray();
                result.AddRange(roles);

                if (cascade
                    &&
                    roles.Any())
                {
                    roles = GetDeriveRolesOfRoles(roles);
                    result.AddRange(roles);
                }
            }
            return result;
        }

        /// <summary>
        /// <see cref="IRoleInheritRelationService"/>
        /// </summary>
        /// <param name="roles"><see cref="IRoleInheritRelationService"/></param>
        /// <returns><see cref="IRoleInheritRelationService"/></returns>
        public IEnumerable<Role> GetDeriveRolesOfRoles(IEnumerable<Role> roles)
        {
            Guidance.ArgumentNotNull(roles, "roles");

            var list = new List<Role>();
            while (roles.Any())
            {
                var roleIds = roles.Select(r => r.Id);
                roles = RoleInheritRelations
                    .Where(ri => roleIds.Contains(ri.InheritRole.Id))
                    .Select(ri => ri.Role)
                    .ToArray();
                list.AddRange(roles);
            }
            return list;
        }

        /// <summary>
        /// <see cref="IRoleInheritRelationService"/>
        /// </summary>
        /// <param name="roles"><see cref="IRoleInheritRelationService"/></param>
        /// <returns><see cref="IRoleInheritRelationService"/></returns>
        public IEnumerable<Role> GetInheritRolesOfRoles(IEnumerable<Role> roles)
        {
            Guidance.ArgumentNotNull(roles, "roles");

            var list = new List<Role>();
            while (roles.Any())
            {
                var roleIds = roles.Select(r => r.Id);
                roles = RoleInheritRelations
                    .Where(ri => roleIds.Contains(ri.Role.Id))
                    .Select(ri => ri.InheritRole)
                    .ToArray();
                list.AddRange(roles);
            }
            return list;
        }

        #endregion
    }
}