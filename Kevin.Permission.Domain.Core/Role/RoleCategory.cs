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
            get
            {
                return _inheritType;
            }
            set
            {
                if (!Enum.IsDefined(typeof(RoleInheritType), value))
                {
                    throw new ArgumentException(Resource.Messages.exception_InvalidInheritValue);
                }
            }
        }
        private int _inheritType;

        /// <summary>
        /// 角色类型的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色类型的编码
        /// </summary>
        public string Code { get; set; }

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
