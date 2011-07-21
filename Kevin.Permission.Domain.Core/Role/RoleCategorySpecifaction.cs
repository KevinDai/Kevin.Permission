using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 根据角色类型筛选角色的规约类
    /// </summary>
    public class RoleCategorySpecifaction : Specification<Role>
    {

        #region Members

        /// <summary>
        /// 角色类型对象标识符
        /// </summary>
        public int RoleCategoryId
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public RoleCategorySpecifaction(int roleCategoryId)
        {
            RoleCategoryId = roleCategoryId;
        }

        #endregion

        #region Specification<Role> implementation

        /// <summary>
        /// <see cref="Specification{Role}"/>
        /// </summary>
        /// <returns><see cref="Specification{Role}"/></returns>
        public override Expression<Func<Role, bool>> SatisfiedBy()
        {
            return r => r.Category.Id == RoleCategoryId;
        }

        #endregion
    }
}
