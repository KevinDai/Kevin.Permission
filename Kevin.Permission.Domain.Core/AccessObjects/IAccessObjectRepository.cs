using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.AccessObjects
{
    /// <summary>
    /// 访问对象数据仓库接口
    /// </summary>
    public interface IAccessObjectRepository : IRepository<AccessObject, int>
    {
    }
}
