using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 根据角色筛选与角色关联的权限配置对象规约类
    /// </summary>
    public class PermissionConfigBaseRolesSpecification : Specification<PermissionConfigBase>
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
            if (roleIds == null
                ||
                !roleIds.Any())
            {
                throw new ArgumentException(
                    Resource.Messages.exception_PermissionConfigBaseRolesSpecification_InvalidRoleIds
                    , "roleIds");
            }
            RoleIds = roleIds;
        }

        #endregion

        #region Specification<Role> implementation

        public override Expression<Func<PermissionConfigBase, bool>> SatisfiedBy()
        {
            return p => RoleIds.Contains(p.Role.Id);
        }

        #endregion

    }
}
