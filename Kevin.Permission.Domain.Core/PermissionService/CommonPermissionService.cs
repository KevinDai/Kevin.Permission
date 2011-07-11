using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 普通权限计算服务类
    /// </summary>
    public class CommonPermissionService : ICommonPermissionService
    {

        #region Members

        /// <summary>
        /// 角色数据仓库接口实例对象
        /// </summary>
        protected IRoleRepository RoleRepository
        {
            get;
            private set;
        }

        /// <summary>
        /// 普通的权限配置对象数据仓库接口实例对象
        /// </summary>
        protected ICommonPermissionConfigRepository CommonPermissionConfigRepository
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public CommonPermissionService(
            IRoleRepository roleRepository,
            ICommonPermissionConfigRepository commonPermissionConfigRepository)
        {
            RoleRepository = roleRepository;
            CommonPermissionConfigRepository = commonPermissionConfigRepository;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 获取用户所属的角色列表以及这些角色继承的角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>角色列表</returns>
        protected IEnumerable<Role> GetRolesOfUserWithInheritRoles(User user)
        {
            //用户所属的角色列表
            var roles = RoleRepository.GetRolesOfUser(user);
            if (roles.Any())
            {
                //级联查询指定角色列表中角色继承的角色列表
                var inheritRoles = RoleRepository.GetInheritRolesOfRoles(roles);
                if (inheritRoles.Any())
                {
                    roles = roles.Union(inheritRoles);
                }
            }
            return roles;
        }

        protected IEnumerable<CommonPermissionConfig> GetPermissionConfigs(IEnumerable<Role> roles, AccessObject accessObject)
        {
            //根据角色列表以及访问对象查询相关的权限配置对象
            var pcbRolesSpec = new PermissionConfigBaseRolesSpecification(roles.Select(r => r.Id));
            var pcbAccessObjectSpec = new PermissionConfigBaseAccessObjectSpecification(accessObject.Id);
            var spec = (pcbRolesSpec & pcbRolesSpec).OfType<CommonPermissionConfig>();

            var configs = CommonPermissionConfigRepository.FindBy(spec);
            return configs;
        }

        #endregion

        #region ICommonPermissionService implementation

        /// <summary>
        /// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/>
        /// </summary>
        /// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></param>
        /// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></param>
        /// <param name="operation"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></param>
        /// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></returns>
        public bool HavePermission(User user, AccessObject accessObject, Operation operation)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            if (accessObject == null)
            {
                throw new ArgumentNullException("accessObject");
            }
            if (operation == null)
            {
                throw new ArgumentNullException("operation");
            }
            if (accessObject.RangeAccess)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_AccessObjectRangeAccessNeedFalse,
                    "accessObject");
            }
            if (!accessObject.Operations.Contains(operation))
            {
                throw new ArgumentException(
                    Resource.Messages.exception_AccessObjectNotContainsOperation,
                    "operation");
            }

            bool result = false;
            //查询用户关联的角色列表
            var roles = GetRolesOfUserWithInheritRoles(user);
            if (roles.Any())
            {
                var configs = GetPermissionConfigs(roles, accessObject);
            }

            return result;
        }

        /// <summary>
        /// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/>
        /// </summary>
        /// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></param>
        /// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></param>
        /// <param name="operation"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></param>
        /// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></returns>
        public bool HaveAllPermission(User user, AccessObject accessObject, IEnumerable<Operation> operation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/>
        /// </summary>
        /// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></param>
        /// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></param>
        /// <param name="operation"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></param>
        /// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></returns>
        public bool HaveAnyPermission(User user, AccessObject accessObject, IEnumerable<Operation> operation)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
