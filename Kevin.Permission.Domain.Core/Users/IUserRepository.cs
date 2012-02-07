using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.Users
{
    /// <summary>
    /// 用户数据仓库接口
    /// </summary>
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
