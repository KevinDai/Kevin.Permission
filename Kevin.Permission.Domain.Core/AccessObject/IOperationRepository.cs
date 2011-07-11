using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 操作类型数据仓库接口
    /// </summary>
    public interface IOperationRepository : IRepository<Operation, int>
    {
    }
}
