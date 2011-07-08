using System;
using System.Collections.Generic;
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
            set;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain.Validate"/>
        /// </summary>
        protected override void Validate()
        {
        }

        #endregion
    }
}
