﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.PermissionConfigs
{
    using AccessObjects;
    using Roles;
    using Kevin.Permission.Infrastructure;
    using Kevin.Permission.Infrastructure.Entity;

    /// <summary>
    /// 权限配置对象类
    /// </summary>
    public class PermissionConfig : EntityBase<int>, IAggregateRoot, ILock
    {

        #region Members

        /// <summary>
        /// 角色
        /// </summary>
        public Role Role
        {
            get;
            private set;
        }

        /// <summary>
        /// 访问对象
        /// </summary>
        public AccessObject AccessObject
        {
            get;
            private set;
        }

        /// <summary>
        /// 对访问对象的操作权限配置列表
        /// </summary>
        public ICollection<OperationPermissionConfig> OperationPermissionConfigs
        {
            get
            {
                if (_locked)
                {
                    return _readOnlyOperationPermissionCinfigs;
                }
                else
                {
                    return _operationPermissionConfigs;
                }
            }
        }
        private ReadOnlyCollection<OperationPermissionConfig> _readOnlyOperationPermissionCinfigs;
        private IList<OperationPermissionConfig> _operationPermissionConfigs;

        #endregion

        #region Constructor

        public PermissionConfig()
        {
            _operationPermissionConfigs = new List<OperationPermissionConfig>();
            _readOnlyOperationPermissionCinfigs = new ReadOnlyCollection<OperationPermissionConfig>(_operationPermissionConfigs);
        }

        public PermissionConfig(Role role, AccessObject accessObject)
            : this()
        {
            Guidance.ArgumentNotNull(role, "role");
            Guidance.ArgumentNotNull(accessObject, "accessObject");

            Role = role;
            AccessObject = accessObject;
            OperationConfigCollectionInitialize();
            //初始化完成后锁定对象
            Lock();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 初始化对访问对象的操作权限配置列表
        /// </summary>
        private void OperationConfigCollectionInitialize()
        {
            foreach (var operation in AccessObject.Operations)
            {
                _operationPermissionConfigs.Add(new OperationPermissionConfig(this, operation));
            }
        }

        /// <summary>
        /// 获取权限配置对象中配置为允许操作的操作列表
        /// </summary>
        /// <returns>操作列表</returns>
        public IEnumerable<Operation> GetSetPermitStatusOperations()
        {
            var operations = OperationPermissionConfigs.Where(oc => oc.Permit).Select(oc => oc.Operation);
            return operations;
        }

        /// <summary>
        /// 获取权限配置对象中配置为拒绝操作的操作列表
        /// </summary>
        /// <returns>操作列表</returns>
        public IEnumerable<Operation> GetSetDenyStatusOperations()
        {
            var operations = OperationPermissionConfigs.Where(oc => oc.Deny).Select(oc => oc.Operation);
            return operations;
        }

        /// <summary>
        /// 获取指定操作对象的操作权限配置对象
        /// </summary>
        /// <param name="operation">操作对象</param>
        /// <returns>操作权限配置对象</returns>
        public OperationPermissionConfig GetOperationConfig(Operation operation)
        {
            return OperationPermissionConfigs.SingleOrDefault(oc => oc.Operation == operation);
        }

        /// <summary>
        /// 设置指定操作对象的权限
        /// </summary>
        /// <param name="operation">操作对象</param>
        /// <param name="permit">是否设置为允许</param>
        /// <param name="deny">是否设置为拒绝</param>
        public void SetOperationPermission(Operation operation, bool permit, bool deny)
        {
            var operationConfig = GetOperationConfig(operation);
            if (operationConfig == null)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_PermissionConfigBase_SetOperationPermission_OperationInvalid
                    , "operation");
            }
            operationConfig.Permit = permit;
            operationConfig.Deny = deny;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain"/>
        /// </summary>
        protected override void Validate()
        {
            if (Role == null)
            {
                AddBrokenRule(new BusinessRule("Role", "配置权限的角色对象无效"));
            }
            if (AccessObject == null)
            {
                AddBrokenRule(new BusinessRule("AccessObject", "配置权限的防伪对象无效"));
            }
        }

        #endregion

        #region ILock implementation

        /// <summary>
        /// <see cref="ILock"/>
        /// </summary>
        public void Lock()
        {
            _locked = true;
        }

        /// <summary>
        /// <see cref="ILock"/>
        /// </summary>
        public bool Locked
        {
            get
            {
                return _locked;
            }
        }
        private bool _locked;

        #endregion
    }
}
