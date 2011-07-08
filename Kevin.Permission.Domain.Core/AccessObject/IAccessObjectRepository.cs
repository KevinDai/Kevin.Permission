using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 访问对象数据仓库
    /// </summary>
    public interface IAccessObjectRepository : IRepository<AccessObject, int>
    {

        /// <summary>
        /// 获取属于指定模块的所有访问对象列表
        /// </summary>
        /// <param name="module">指定模块</param>
        /// <returns>访问对象列表</returns>
        IEnumerable<AccessObject> GetAccessObjectOfMudule(Module module);

    }
}
