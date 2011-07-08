using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 用户角色关联信息数据仓库接口定义
    /// </summary>
    public interface IUserRoleRelationRepository : IRepository<UserRoleRelation, int>
    {
        /// <summary>
        /// 清除用户关联的所有用户角色关联信息对象
        /// </summary>
        /// <param name="user"></param>
        void ClearRelationsOfUser(User user);
        /// <summary>
        /// 清除角色关联的所有用户角色关联信息对象
        /// </summary>
        /// <param name="role"></param>
        void ClearRelationsOfRole(Role role);
    }
}
