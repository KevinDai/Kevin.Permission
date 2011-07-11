using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 操作权限类
    /// </summary>
    public class OperationPermission
    {

        #region Members

        /// <summary>
        /// 操作
        /// </summary>
        public Operation Operation
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否允许进行操作
        /// </summary>
        protected bool Deny
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否拒绝进行操作
        /// </summary>
        protected bool Permit
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否拥有操作权限
        /// </summary>
        public bool HavePermission
        {
            get
            {
                //拒绝优先
                if (Deny)
                {
                    return false;
                }
                else
                {
                    return Permit;
                }
            }
        }

        #endregion

        #region Constructor

        public OperationPermission(Operation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException("operation");
            }
            Operation = operation;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 根据操作权限配置计算权限
        /// </summary>
        /// <param name="operation">操作权限配置</param>
        public virtual void PermissionCalculate(OperationPermissionConfig operationConfig)
        {
            if (operationConfig == null)
            {
                throw new ArgumentNullException("operationConfig");
            }
            if (operationConfig.Operation != Operation)
            {
                throw new ArgumentException(
                    Resource.Messages.exception_OperationPermissionCalculateInvalidOperationConfig,
                    "operationConfig");
            }

            Deny = operationConfig.Deny || Deny;
            Permit = operationConfig.Permit || Permit;
        }

        #endregion

    }
}
