using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 用户角色对象根据用户进行筛选的规约类
    /// </summary>
    public class UserRoleRelationUserSpecification : Specification<UserRoleRelation>
    {
        #region Members

        /// <summary>
        /// 用户标识符
        /// </summary>
        public int UserId
        {
            get;
            private set;
        }


        #endregion

        #region Constructor

        public UserRoleRelationUserSpecification(int userId)
        {
            UserId = userId;
        }

        #endregion

        #region Specification<UserRoleRelation> implementation

        /// <summary>
        /// <see cref="Specification{UserRoleRelation}"/>
        /// </summary>
        /// <returns><see cref="Specification{UserRoleRelation}"/></returns>
        public override Expression<Func<UserRoleRelation, bool>> SatisfiedBy()
        {
            return urr => urr.User.Id == UserId;
        }

        #endregion
    }
}
