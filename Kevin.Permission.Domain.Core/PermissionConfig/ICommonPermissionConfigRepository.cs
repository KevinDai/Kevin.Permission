using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 普通的权限配置对象数据仓库
    /// </summary>
    public interface ICommonPermissionConfigRepository : IRepository<CommonPermissionConfig, int>
    {
    }
}
