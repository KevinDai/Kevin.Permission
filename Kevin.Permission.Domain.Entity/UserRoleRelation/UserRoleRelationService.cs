using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    /// <summary>
    /// 用户角色关系对象数据仓库类
    /// </summary>
    public class UserRoleRelationService : IUserRoleRelationService
    {

        #region Members

        protected IEntityUnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public UserRoleRelationService(IEntityUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取用户角色关联关系对象
        /// </summary>
        /// <param name="role">用户</param>
        /// <param name="user">角色</param>
        /// <returns></returns>
        private UserRoleRelation Get(User user, Role role)
        {
            var relation = UnitOfWork.DbSet<UserRoleRelation, int>()
                .FirstOrDefault(urr =>
                    urr.Role.Id == role.Id
                    &&
                    urr.User.Id == user.Id);
            return relation;
        }

        /// <summary>
        /// 查询角色相关的关联关系对象
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns>用户角色关联关系对象查询对象</returns>
        private IQueryable<UserRoleRelation> GetRelationsOfRole(Role role)
        {
            var relations = UnitOfWork.DbSet<UserRoleRelation, int>()
                .Where(urr => urr.Role.Id == role.Id);
            return relations;
        }

        /// <summary>
        /// 查询用户相关的关联关系对象
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>用户角色关联关系对象查询对象</returns>
        private IQueryable<UserRoleRelation> GetRelationsOfUser(User user)
        {
            var relations = UnitOfWork.DbSet<UserRoleRelation, int>()
                .Where(urr => urr.User.Id == user.Id);
            return relations;
        }

        /// <summary>
        /// 删除多个用户角色关联对象
        /// </summary>
        /// <param name="relations">用户角色关联对象列表</param>
        private void Remove(IEnumerable<UserRoleRelation> relations)
        {
            foreach (var item in relations)
            {
                Remove(item);
            }
        }

        /// <summary>
        /// 删除用户角色关联对象
        /// </summary>
        /// <param name="relation"></param>
        private void Remove(UserRoleRelation relation)
        {
            UnitOfWork.RegisterRemove<UserRoleRelation, int>(relation);
        }

        #endregion

        #region IUserRoleRelationRepository implementation

        /// <summary>
        /// <see cref="IUserRoleRelationService"/>
        /// </summary>
        /// <param name="user"><see cref="IUserRoleRelationService"/></param>
        /// <param name="role"><see cref="IUserRoleRelationService"/></param>
        public void AddRelation(User user, Role role)
        {
            Guidance.ArgumentNotNull(user, "user");
            Guidance.ArgumentNotNull(role, "role");

            var relation = new UserRoleRelation(user, role);

            UnitOfWork.RegisterNew<UserRoleRelation, int>(relation);
        }

        /// <summary>
        /// <see cref="IUserRoleRelationService"/>
        /// </summary>
        /// <param name="user"><see cref="IUserRoleRelationService"/></param>
        /// <param name="role"><see cref="IUserRoleRelationService"/></param>
        public void RemoveRelation(User user, Role role)
        {
            Guidance.ArgumentNotNull(user, "user");
            Guidance.ArgumentNotNull(role, "role");

            var relation = Get(user, role);
            Remove(relation);
        }

        /// <summary>
        /// <see cref="IUserRoleRelationService"/>
        /// </summary>
        /// <param name="user"><see cref="IUserRoleRelationService"/></param>
        /// <returns><see cref="IUserRoleRelationService"/></returns>
        public IEnumerable<Role> GetRolesOfUser(User user)
        {
            Guidance.ArgumentNotNull(user, "user");

            var relations = GetRelationsOfUser(user);

            var roles = relations.Select(urr => urr.Role).ToArray();
            return roles;
        }

        /// <summary>
        /// <see cref="IUserRoleRelationService"/>
        /// </summary>
        /// <param name="role"><see cref="IUserRoleRelationService"/></param>
        /// <returns><see cref="IUserRoleRelationService"/></returns>
        public IEnumerable<User> GetUsersOfRole(Role role)
        {
            Guidance.ArgumentNotNull(role, "role");

            var relations = GetRelationsOfRole(role);

            var users = relations.Select(urr => urr.User).ToArray();
            return users;
        }

        /// <summary>
        /// <see cref="IUserRoleRelationService"/>
        /// </summary>
        /// <param name="user"><see cref="IUserRoleRelationService"/></param>
        public void ClearRelationsOfUser(User user)
        {
            Guidance.ArgumentNotNull(user, "user");

            var relations = GetRelationsOfUser(user);

            Remove(relations);
        }

        /// <summary>
        /// <see cref="IUserRoleRelationService"/>
        /// </summary>
        /// <param name="role"><see cref="IUserRoleRelationService"/></param>
        public void ClearRelationsOfRole(Role role)
        {
            Guidance.ArgumentNotNull(role, "role");

            var relations = GetRelationsOfRole(role);

            Remove(relations);
        }

        #endregion

    }
}
