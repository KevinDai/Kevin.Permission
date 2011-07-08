using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 角色类型数据仓库
    /// </summary>
    public interface IRoleCategoryRepository : IRepository<RoleCategory, int>
    {
    }
}
