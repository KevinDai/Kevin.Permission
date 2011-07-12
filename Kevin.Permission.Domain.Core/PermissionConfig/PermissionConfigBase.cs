using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 权限配置对象基类
    /// </summary>
    public abstract class PermissionConfigBase : EntityBase<int>
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
            get;
            private set;
        }

        #endregion

        #region Constructor

        public PermissionConfigBase()
        {
        }

        public PermissionConfigBase(Role role, AccessObject accessObject)
        {
            Guidance.ArgumentNotNull(role, "role");
            Guidance.ArgumentNotNull(accessObject, "accessObject");

            Role = role;
            AccessObject = accessObject;
            OperationConfigCollectionInitialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// 初始化对访问对象的操作权限配置列表
        /// </summary>
        private void OperationConfigCollectionInitialize()
        {
            List<OperationPermissionConfig> list = new List<OperationPermissionConfig>();
            foreach (var operation in AccessObject.Operations)
            {
                list.Add(new OperationPermissionConfig(this, operation));
            }
            this.OperationPermissionConfigs = new ReadOnlyCollection<OperationPermissionConfig>(list);
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
        /// <see cref="Kevin.Infrastructure.Domain.Validate"/>
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
    }
}
