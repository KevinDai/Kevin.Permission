using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 普通权限计算服务接口
    /// </summary>
    public interface ICommonPermissionService
    {
        /// <summary>
        /// 判断用户是否拥对访问对象的操作的权限
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="accessObject">访问对象</param>
        /// <param name="operation">操作</param>
        /// <returns>是否拥有权限</returns>
        bool HavePermission(User user, AccessObject accessObject, Operation operation);

        /// <summary>
        /// 判断用户是否拥有对访问对象的一组操作中所有操作的权限
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="accessObject">访问对象</param>
        /// <param name="operations">操作列表</param>
        /// <returns>是否拥有权限</returns>
        bool HaveAllPermission(User user, AccessObject accessObject, IEnumerable<Operation> operations);

        /// <summary>
        /// 判断用户是否拥有对访问对象的一组操作中任意某一个操作的权限
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="accessObject">访问对象</param>
        /// <param name="operations">操作列表</param>
        /// <returns>是否拥有权限</returns>
        bool HaveAnyPermission(User user, AccessObject accessObject, IEnumerable<Operation> operations);

    }
}
