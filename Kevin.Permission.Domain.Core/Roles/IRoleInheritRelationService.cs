using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core.Roles
{
    /// <summary>
    /// 角色继承关系服务接口
    /// </summary>
    public interface IRoleInheritRelationService 
    {

        /// <summary>
        /// 添加角色的继承关系
        /// </summary>
        /// <param name="role">当前角色</param>
        /// <param name="inheritRole">继承的角色</param>
        void AddRelation(Role role, Role inheritRole);

        /// <summary>
        /// 移除角色的继承关系
        /// </summary>
        /// <param name="role">当前角色</param>
        /// <param name="inheritRole">继承的角色</param>
        void RemoveRelation(Role role, Role inheritRole);

        /// <summary>
        /// 获取指定角色继承的角色（父角色）列表
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cascade">是否级联查询</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetInheritRolesOfRole(Role role, bool cascade);

        /// <summary>
        /// 获取继承了指定角色的角色（子角色）列表
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="cascade">是否级联查询</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetDeriveRolesOfRole(Role role, bool cascade);

        /// <summary>
        /// 级联查询继承了指定角色列表中角色的角色列表
        /// </summary>
        /// <param name="roles">角色列表</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetDeriveRolesOfRoles(IEnumerable<Role> roles);

        /// <summary>
        /// 级联查询指定角色列表中角色继承的角色列表
        /// </summary>
        /// <param name="roles">角色列表</param>
        /// <returns>角色列表</returns>
        IEnumerable<Role> GetInheritRolesOfRoles(IEnumerable<Role> roles);

    }
}
