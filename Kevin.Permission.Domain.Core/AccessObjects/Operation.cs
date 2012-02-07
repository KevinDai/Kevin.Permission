using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.AccessObjects
{
    /// <summary>
    /// 操作对象类
    /// <example>
    /// 查看，编辑，管理
    /// </example>
    /// </summary>
    public class Operation : EntityBase<int>, IAggregateRoot
    {

        #region Members

        /// <summary>
        /// 操作名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 操作编码
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
                AddBrokenRule(new BusinessRule("Name", "必须输入操作名称"));
            }
            if (string.IsNullOrEmpty(Code))
            {
                AddBrokenRule(new BusinessRule("Code", "必须输入操作编码"));
            }
        }

        #endregion
    }
}
