using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 角色数据仓库接口
    /// </summary>
    public interface IRoleRepository : IRepository<Role, int>
    {

        /// <summary>
        /// 获取属于指定用户的所有角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetRolesOfUser(User user);

        /// <summary>
        /// 添加角色的父子继承关系
        /// </summary>
        /// <param name="role">子角色</param>
        /// <param name="inheritRole">父角色</param>
        void AddInheritRoleOfRole(Role role, Role inheritRole);

        /// <summary>
        /// 移除角色的父子继承关系
        /// </summary>
        /// <param name="role">子角色</param>
        /// <param name="inheritRole">父角色</param>
        void RemoveInheritRoleOfRole(Role role, Role inheritRole);

        /// <summary>
        /// 获取指定角色继承角色（父角色）列表
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cascade">是否级联查询</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetInheritRolesOfRole(Role role, bool cascade);

        /// <summary>
        /// 获取指定角色派生角色（子角色）列表
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cascade">是否级联查询</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetDeriveRolesOfRole(Role role, bool cascade);

        /// <summary>
        /// 级联查询指定角色列表中角色继承的角色列表
        /// </summary>
        /// <param name="roles">角色列表</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetInheritRolesOfRoles(IEnumerable<Role> roles);

    }
}
