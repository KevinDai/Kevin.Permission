using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    /// <summary>
    /// 角色继承关联类
    /// </summary>
    internal class RoleInheritRelation : EntityBase<int>, IAggregateRoot
    {

        #region Members

        /// <summary>
        /// 当前角色
        /// </summary>
        public Role Role
        {
            get;
            private set;
        }

        /// <summary>
        /// 继承的角色
        /// </summary>
        public Role InheritRole
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public RoleInheritRelation()
        {
        }

        public RoleInheritRelation(Role role, Role inheritRole)
        {
            Guidance.ArgumentNotNull(role, "role");
            Guidance.ArgumentNotNull(inheritRole, "inheritRole");

            Role = role;
            InheritRole = inheritRole;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain"/>
        /// </summary>
        protected override void Validate()
        {
            if (Role == null)
            {
                AddBrokenRule(new BusinessRule("Role", "无效的角色对象"));
            }
            if (InheritRole == null)
            {
                AddBrokenRule(new BusinessRule("InheritRole", "无效的继承的角色对象"));
            }
        }

        #endregion

    }
}