using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 操作的权限配置对象
    /// </summary>
    public class OperationPermissionConfig : EntityBase<int>
    {

        #region Members

        /// <summary>
        /// 所属权限配置对象
        /// </summary>
        public PermissionConfig PermissionConfig
        {
            get;
            private set;
        }

        /// <summary>
        /// 配置权限的操作对象
        /// </summary>
        public Operation Operation
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否允许进行操作
        /// </summary>
        public bool Permit
        {
            get;
            set;
        }

        /// <summary>
        /// 是否拒绝进行操作
        /// </summary>
        public bool Deny
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public OperationPermissionConfig()
        {
        }

        public OperationPermissionConfig(PermissionConfig permissionConfig, Operation operation)
        {
            PermissionConfig = permissionConfig;
            Operation = operation;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain"/>
        /// </summary>
        protected override void Validate()
        {
            if (PermissionConfig == null)
            {
                AddBrokenRule(new BusinessRule("PermissionConfig", "操作权限配置对象所属的权限配置对象无效"));
            }
            if (Operation == null)
            {
                AddBrokenRule(new BusinessRule("Operation", "操作权限配置对象的操作对象无效"));
            }
        }

        #endregion
    }
}
