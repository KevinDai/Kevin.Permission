using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 模块信息数据仓库
    /// </summary>
    public interface IModuleRepository : IRepository<Module, int>
    {
    }
}
