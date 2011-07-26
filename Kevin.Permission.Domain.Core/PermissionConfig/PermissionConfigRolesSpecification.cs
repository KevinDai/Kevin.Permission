using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    using Kevin.Permission.Infrastructure;

    /// <summary>
    /// 根据角色筛选与角色关联的权限配置对象规约类
    /// </summary>
    public class PermissionConfigBaseRolesSpecification : Specification<PermissionConfig>
    {

        #region Members

        /// <summary>
        /// 角色标识符列表
        /// </summary>
        public IEnumerable<int> RoleIds
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public PermissionConfigBaseRolesSpecification(IEnumerable<int> roleIds)
        {
            Guidance.IEnumerableNotNull(
                roleIds,
                "roleIds",
                Resource.Messages.exception_PermissionConfigBaseRolesSpecification_InvalidRoleIds);

            RoleIds = roleIds;
        }

        #endregion

        #region Specification<PermissionConfigBase> implementation

        /// <summary>
        /// <see cref="Specification{PermissionConfigBase}"/>
        /// </summary>
        /// <returns><see cref="Specification{PermissionConfigBase}"/></returns>
        public override Expression<Func<PermissionConfig, bool>> SatisfiedBy()
        {
            return p => RoleIds.Contains(p.Role.Id);
        }

        #endregion

    }
}
