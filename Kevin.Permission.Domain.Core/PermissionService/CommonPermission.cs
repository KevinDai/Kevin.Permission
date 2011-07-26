using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core
{
    using Kevin.Permission.Infrastructure;

    /// <summary>
    /// 普通权限类
    /// </summary>
    public class CommonPermission
    {
        #region Members

        /// <summary>
        /// 权限的访问对象
        /// </summary>
        public AccessObject AccessObject
        {
            get;
            private set;
        }

        /// <summary>
        /// 进行权限计算的权限配置列表
        /// </summary>
        public IEnumerable<CommonPermissionConfig> PermissionConfigs
        {
            get
            {
                return _permissionConfigs;
            }
        }
        private IList<CommonPermissionConfig> _permissionConfigs;

        /// <summary>
        /// 操作的权限列表
        /// </summary>
        public IEnumerable<OperationPermission> OperationPermissions
        {
            get
            {
                return _operationPermissions.Values;
            }
        }
        private IDictionary<int, OperationPermission> _operationPermissions;

        #endregion

        #region Constructor

        public CommonPermission(AccessObject accessObject)
            : this(accessObject, new CommonPermissionConfig[] { })
        {
        }

        public CommonPermission(AccessObject accessObject, IEnumerable<CommonPermissionConfig> permissionConfigs)
        {
            Guidance.ArgumentNotNull(accessObject, "accessObject");
            Guidance.ArgumentNotNull(permissionConfigs, "permissionConfigs");
            if (accessObject.RangeAccess)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_AccessObjectRangeAccessNeedFalse,
                    "accessObject");
            }

            AccessObject = accessObject;
            _permissionConfigs = new List<CommonPermissionConfig>(permissionConfigs);

            OperationPermissionsInitialize();
            PermissionCalculate();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 初始化操作权限列表
        /// </summary>
        private void OperationPermissionsInitialize()
        {
            _operationPermissions = new Dictionary<int, OperationPermission>();
            foreach (var operation in AccessObject.Operations)
            {
                _operationPermissions.Add(operation.Id, new OperationPermission(operation));
            }
        }

        /// <summary>
        /// 根据权限配置进行计算权限
        /// </summary>
        private void PermissionCalculate()
        {
            foreach (var config in _permissionConfigs)
            {
                PermissionCalculate(config, false);
            }
        }

        /// <summary>
        /// 根据权限配置进行计算权限
        /// </summary>
        /// <param name="permissionConfig">权限配置</param>
        /// <param name="append">是否添加配置对象到配置对象列表</param>
        private void PermissionCalculate(CommonPermissionConfig permissionConfig, bool append)
        {
            Guidance.ArgumentNotNull(permissionConfig, "permissionConfig");

            if (permissionConfig.AccessObject != AccessObject)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_CommonPermissionPermissionCalculateInvalidAccessObject,
                    "permissionConfig");
            }

            //根据权限配置对象更新操作的权限
            foreach (var operationPermissionConfig in permissionConfig.OperationPermissionConfigs)
            {
                if (_operationPermissions.ContainsKey(operationPermissionConfig.Operation.Id))
                {
                    _operationPermissions[operationPermissionConfig.Operation.Id]
                        .PermissionCalculate(operationPermissionConfig);
                }
                else
                {
                    throw new InvalidOperationException(
                        Resource.Messages.exception_CommonPermissionPermissionCalculateInvalidAccessObject);
                }
            }

            if (append)
            {
                //添加配置对象到配置对象列表
                _permissionConfigs.Add(permissionConfig);
            }
        }

        /// <summary>
        /// 根据权限配置进行计算权限
        /// </summary>
        /// <param name="permissionConfig">权限配置</param>
        public void PermissionCalculate(CommonPermissionConfig permissionConfig)
        {
            PermissionCalculate(permissionConfig, true);
        }

        /// <summary>
        /// 是否拥有指定操作的权限
        /// </summary>
        /// <param name="operation">操作</param>
        /// <returns>是否拥有权限</returns>
        public bool HavePermission(Operation operation)
        {
            Guidance.ArgumentNotNull(operation, "operation");

            return GetOperationPermission(operation).HavePermission;
        }

        /// <summary>
        /// 查询指定操作的操作权限
        /// </summary>
        /// <param name="operation">操作</param>
        /// <returns>操作权限</returns>
        public OperationPermission GetOperationPermission(Operation operation)
        {
            Guidance.ArgumentNotNull(operation, "operation");

            if (_operationPermissions.ContainsKey(operation.Id))
            {
                return _operationPermissions[operation.Id];
            }
            else
            {
                throw new ArgumentException(
                    Resource.Messages.exception_CommonPermissionNotContainsOperation,
                    "operation");
            }
        }

        #endregion

    }
}
