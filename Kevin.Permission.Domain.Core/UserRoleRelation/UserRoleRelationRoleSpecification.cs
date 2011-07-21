using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 用户角色对象根据角色进行筛选的规约类
    /// </summary>
    public class UserRoleRelationRoleSpecification : Specification<UserRoleRelation>
    {
        #region Members

        /// <summary>
        /// 角色标识符
        /// </summary>
        public int RoleId
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public UserRoleRelationRoleSpecification(int roleId)
        {
            RoleId = roleId;
        }

        #endregion

        #region Specification<UserRoleRelation> implementation

        /// <summary>
        /// <see cref="Specification{UserRoleRelation}"/>
        /// </summary>
        /// <returns><see cref="Specification{UserRoleRelation}"/></returns>
        public override Expression<Func<UserRoleRelation, bool>> SatisfiedBy()
        {
            return urr => urr.Role.Id == RoleId;
        }

        #endregion

    }
}
