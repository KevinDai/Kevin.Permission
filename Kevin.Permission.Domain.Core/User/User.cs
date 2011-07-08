using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class User : EntityBase<int>, IAggregateRoot
    {

        #region Members

        /// <summary>
        /// 用户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 用户编码，可以标识唯一的用户
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region Constructor

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
