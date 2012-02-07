using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.PermissionConfigs
{
    /// <summary>
    /// 权限配置对象数据仓库接口
    /// </summary>
    public interface IPermissionConfigRepository : IRepository<PermissionConfig, int>
    {
    }
}
