using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Entity.UserRoleRelation
{
    using Kevin.Permission.Domain.Core.UserRoleRelation;
    using Kevin.Permission.Domain.Core.Users;
    using Kevin.Permission.Domain.Core.Roles;
    using Kevin.Permission.Infrastructure;

    /// <summary>
    /// 用户角色的关联类
    /// </summary>
    internal class UserRoleRelation : EntityBase<int>, IAggregateRoot
    {

        #region Members

        /// <summary>
        /// 用户对象
        /// </summary>
        public User User
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色对象
        /// </summary>
        public Role Role
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public UserRoleRelation()
        {
        }

        public UserRoleRelation(User user, Role role)
        {
            Guidance.ArgumentNotNull(user, "user");
            Guidance.ArgumentNotNull(role, "role");

            User = user;
            Role = role;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain"/>
        /// </summary>
        protected override void Validate()
        {
            if (User == null)
            {
                AddBrokenRule(new BusinessRule("User", "无效的用户对象"));
            }
            if (Role == null)
            {
                AddBrokenRule(new BusinessRule("Role", "无效的角色对象"));
            }
        }

        #endregion
    }
}
