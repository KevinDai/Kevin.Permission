using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 角色类
    /// </summary>
    public class Role : EntityBase<int>, IAggregateRoot
    {
        #region Members

        /// <summary>
        /// 角色类型
        /// </summary>
        public RoleCategory Category { get; private set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        public string Code { get; set; }

        #endregion

        #region Constructor

        public Role()
        {
        }

        public Role(RoleCategory roleCategory)
        {
            Guidance.ArgumentNotNull(roleCategory, "roleCategory");

            Category = Category;
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
                AddBrokenRule(new BusinessRule("Name", "必须输入角色名称"));
            }
        }

        #endregion
    }
}
