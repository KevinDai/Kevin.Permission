using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.UserRoleRelation
{
    using Users;
    using Roles;

    /// <summary>
    /// 用户角色关联关系服务接口
    /// </summary>
    public interface IUserRoleRelationService 
    {

        /// <summary>
        /// 添加用户角色的关联关系
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="role">角色</param>
        void AddRelation(User user, Role role);

        /// <summary>
        /// 移除用户角色的关联关系
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="role">角色</param>
        void RemoveRelation(User user, Role role);

        /// <summary>
        /// 获取属于指定角色的所有的用户
        /// </summary>
        /// <param name="role">指定角色</param>
        /// <returns>用户列表</returns>
        IEnumerable<User> GetUsersOfRole(Role role);

        /// <summary>
        /// 获取属于指定用户的所有角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetRolesOfUser(User user);

        /// <summary>
        /// 清除用户关联的所有用户角色关联对象
        /// </summary>
        /// <param name="user"></param>
        void ClearRelationsOfUser(User user);

        /// <summary>
        /// 清除角色关联的所有用户角色关联对象
        /// </summary>
        /// <param name="role"></param>
        void ClearRelationsOfRole(Role role);
    }
}
