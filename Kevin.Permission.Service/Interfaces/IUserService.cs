using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Service.Interfaces
{
    using Kevin.Permission.Domain.Core;
    using Kevin.Permission.Domain.Core.Users;
    using Kevin.Permission.Infrastructure.Model;

    public interface IUserService
    {
        /// <summary>
        /// 获取用户分页列表
        /// </summary>
        /// <param name="specification">筛选规约</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="sortDescriptors">排序描述对象</param>
        /// <returns>用户分页列表对象</returns>
        PageList<User> GetUserPageList(
            ISpecification<User> specification,
            int pageIndex,
            int pageSize,
            params SortDescriptor<User>[] sortDescriptors);
    }
}
