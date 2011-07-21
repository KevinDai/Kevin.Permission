using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 角色类型类
    /// </summary>
    public class RoleCategory : EntityBase<int>, IAggregateRoot
    {
        #region Members

        /// <summary>
        /// 角色的继承类型（考虑Entity暂时不支持枚举类型，使用整形）
        /// </summary>
        public int InheritType
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色类型的名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 角色类型的编码
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        public RoleCategory()
        {
        }

        public RoleCategory(RoleInheritType inheritType)
        {
            InheritType = (int)inheritType;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain"/>
        /// </summary>
        protected override void Validate()
        {
            if (Enum.IsDefined(typeof(RoleInheritType), InheritType))
            {
                AddBrokenRule(new BusinessRule("InheritType", "必须设置有效的角色继承类型"));
            }
        }

        #endregion

    }
}
