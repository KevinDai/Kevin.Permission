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
        /// <see cref="Kevin.Infrastructure.Domain"/>
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddBrokenRule(new BusinessRule("Name", "必须输入模块名称"));
            }
            if (string.IsNullOrEmpty(Code))
            {
                AddBrokenRule(new BusinessRule("Code", "必须输入操作编码"));
            }
        }

        #endregion
    }
}
