using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 模块信息类
    /// </summary>
    public class Module : EntityBase<int>, IAggregateRoot
    {

        #region Members

        /// <summary>
        /// 模块名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 模块编码
        /// </summary>
        public string Code
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
