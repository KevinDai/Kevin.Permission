using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 用户角色的关联信息类
    /// </summary>
    public class UserRoleRelation : EntityBase<int>, IAggregateRoot
    {

        #region Members

        /// <summary>
        /// 用户对象
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// 角色对象
        /// </summary>
        public Role Role { get; set; }

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
