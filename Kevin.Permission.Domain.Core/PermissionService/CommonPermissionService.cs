using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core
{
    using Kevin.Permission.Infrastructure;

    /// <summary>
    /// 普通权限计算服务类
    /// </summary>
    public class CommonPermissionService : ICommonPermissionService
    {

        #region Members

        /// <summary>
        /// 角色数据仓库接口实例对象
        /// </summary>
        protected IUserRoleRelationService UserRoleRelationRepository
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色继承关联数据仓库实例对象
        /// </summary>
        protected IRoleInheritRelationService RoleInheritRelationRepository
        {
            get;
            private set;
        }

        /// <summary>
        /// 普通的权限配置对象数据仓库接口实例对象
        /// </summary>
        protected IPermissionConfigRepository PermissionConfigRepository
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public CommonPermissionService(
            IUserRoleRelationService userRoleRelationRepository,
            IRoleInheritRelationService roleInheritRelationRepository,
            IPermissionConfigRepository permissionConfigRepository)
        {
            UserRoleRelationRepository = userRoleRelationRepository;
            RoleInheritRelationRepository = roleInheritRelationRepository;
            PermissionConfigRepository = permissionConfigRepository;
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
            var roles = UserRoleRelationRepository.GetRolesOfUser(user);
            if (roles.Any())
            {
                //级联查询指定角色列表中角色继承的角色列表
                var inheritRoles = RoleInheritRelationRepository.GetInheritRolesOfRoles(roles);
                if (inheritRoles.Any())
                {
                    roles = roles.Union(inheritRoles);
                }
            }
            return roles;
        }

        /// <summary>
        /// 根据角色列表以及访问对象查询相关的权限配置对象
        /// </summary>
        /// <param name="roles">角色列表</param>
        /// <param name="accessObject">访问对象</param>
        /// <returns>权限配置对象列表</returns>
        protected IEnumerable<PermissionConfig> GetPermissionConfigs(IEnumerable<Role> roles, AccessObject accessObject)
        {
            //根据角色列表以及访问对象查询相关的权限配置对象
            var pcbRolesSpec = new PermissionConfigBaseRolesSpecification(roles.Select(r => r.Id));
            var pcbAccessObjectSpec = new PermissionConfigBaseAccessObjectSpecification(accessObject.Id);
            var spec = pcbRolesSpec & pcbRolesSpec;

            var configs = PermissionConfigRepository.FindBy(spec);
            return configs;
        }

        /// <summary>
        /// 访问对象验证
        /// </summary>
        /// <param name="accessObject">访问对象</param>
        private void AccessObjectArgumentValid(AccessObject accessObject, string argName)
        {
            if (accessObject.RangeAccess)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_AccessObjectRangeAccessNeedFalse,
                    argName);
            }
        }

        #endregion

        #region ICommonPermissionService implementation

        #region 该部分API有点多余，但当如果需要做对具体操作权限的数据库查询优化时候再提供

        ///// <summary>
        ///// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/>
        ///// </summary>
        ///// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></param>
        ///// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></param>
        ///// <param name="operation"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></param>
        ///// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HavePermission"/></returns>
        //public bool HavePermission(User user, AccessObject accessObject, Operation operation)
        //{
        //    Guidance.ArgumentNotNull(user, "user");
        //    Guidance.ArgumentNotNull(accessObject, "accessObject");
        //    Guidance.ArgumentNotNull(operation, "operation");
        //    AccessObjectArgumentValid(accessObject, "accessObject");

        //    //获取权限
        //    var commonPermission = GetCommonPermission(user, accessObject);
        //    return commonPermission.HavePermission(operation);
        //}

        ///// <summary>
        ///// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/>
        ///// </summary>
        ///// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></param>
        ///// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></param>
        ///// <param name="operations"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></param>
        ///// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAllPermission"/></returns>
        //public bool HaveAllPermission(User user, AccessObject accessObject, IEnumerable<Operation> operations)
        //{
        //    Guidance.ArgumentNotNull(user, "user");
        //    Guidance.ArgumentNotNull(accessObject, "accessObject");
        //    Guidance.IEnumerableNotNull(
        //        operations,
        //        "operations",
        //        Resource.Messages.exception_CommonPermissionServiceOperationsNull);
        //    AccessObjectArgumentValid(accessObject, "accessObject");

        //    var commonPermission = GetCommonPermission(user, accessObject);
        //    bool? result = null;
        //    foreach (var operation in operations)
        //    {
        //        result = result.HasValue
        //            ?
        //            commonPermission.HavePermission(operation) && result.Value
        //            :
        //            commonPermission.HavePermission(operation);
        //    }
        //    return result.HasValue
        //        ?
        //        result.Value
        //        :
        //        false;
        //}

        ///// <summary>
        ///// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/>
        ///// </summary>
        ///// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></param>
        ///// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></param>
        ///// <param name="operations"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></param>
        ///// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.HaveAnyPermission"/></returns>
        //public bool HaveAnyPermission(User user, AccessObject accessObject, IEnumerable<Operation> operations)
        //{
        //    Guidance.ArgumentNotNull(user, "user");
        //    Guidance.ArgumentNotNull(accessObject, "accessObject");
        //    Guidance.IEnumerableNotNull(
        //        operations,
        //        "operations",
        //        Resource.Messages.exception_CommonPermissionServiceOperationsNull);
        //    AccessObjectArgumentValid(accessObject, "accessObject");

        //    var commonPermission = GetCommonPermission(user, accessObject);
        //    bool result = false;
        //    foreach (var operation in operations)
        //    {
        //        result = result || commonPermission.HavePermission(operation);
        //    }
        //    return result;
        //}

        #endregion

        /// <summary>
        /// <see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.GetCommonPermission"/>
        /// </summary>
        /// <param name="user"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.GetCommonPermission"/></param>
        /// <param name="accessObject"><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.GetCommonPermission"/></param>
        /// <returns><see cref="Kevin.Permission.Domain.Core.ICommonPermissionService.GetCommonPermission"/></returns>
        public CommonPermission GetCommonPermission(User user, AccessObject accessObject)
        {
            Guidance.ArgumentNotNull(user, "user");
            Guidance.ArgumentNotNull(accessObject, "accessObject");
            AccessObjectArgumentValid(accessObject, "accessObject");

            CommonPermission result = new CommonPermission(accessObject);
            //查询用户关联的角色列表
            var roles = GetRolesOfUserWithInheritRoles(user);
            if (roles.Any())
            {
                //查询权限配置对象列表
                var configs = GetPermissionConfigs(roles, accessObject);
                if (configs.Any())
                {
                    result = new CommonPermission(accessObject, configs);
                }
            }
            return result;
        }

        #endregion

    }

}
