using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core.PermissionService
{
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
            if (accessObject == null)
            {
                throw new ArgumentNullException("accessObject");
            }
            if (permissionConfigs == null)
            {
                throw new ArgumentNullException("permissionConfigs");
            }
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
        /// 权限计算
        /// </summary>
        private void PermissionCalculate()
        {
            foreach (var config in _permissionConfigs)
            {
            }
        }

        /// <summary>
        /// 权限计算
        /// </summary>
        /// <param name="permissionConfig">权限配置</param>
        public void PermissionCalculate(CommonPermissionConfig permissionConfig)
        {
            if (permissionConfig == null)
            {
                throw new ArgumentNullException("permissionConfig");
            }
            if (permissionConfig.AccessObject != AccessObject)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_CommonPermissionPermissionCalculateInvalidAccessObject,
                    "permissionConfig");
            }

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
        }


        #endregion

    }
}
