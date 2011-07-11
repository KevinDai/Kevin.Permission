using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 普通的权限配置对象类
    /// <example>
    /// 某角色对象对某访问对象的各种操作权限配置
    /// </example>
    /// </summary>
    public class CommonPermissionConfig : PermissionConfigBase, IAggregateRoot
    {

        #region Constructor

        public CommonPermissionConfig()
            : base()
        {
        }

        public CommonPermissionConfig(Role role, AccessObject accessObject)
            : base(role, accessObject)
        {
            if (accessObject.RangeAccess)
            {
                throw new ArgumentException(Resource.Messages.exception_AccessObjectRangeAccessNeedFalse, "accessObject");
            }
        }

        #endregion

    }
}
