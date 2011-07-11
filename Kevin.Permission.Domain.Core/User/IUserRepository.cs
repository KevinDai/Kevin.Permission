using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 用户数据仓库接口
    /// </summary>
    public interface IUserRepository : IRepository<User, int>
    {
        /// <summary>
        /// 获取属于指定角色的所有的用户
        /// </summary>
        /// <param name="role">指定角色</param>
        /// <returns>用户列表</returns>
        IEnumerable<User> GetUsersOfRole(Role role);
    }
}
