using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core.Test
{
    [TestClass]
    public class CommonPermissionServiceTest
    {

        [TestMethod]
        public void CommonPermissionService_GetCommonPermission_Test()
        {
            //初始化
            User user = new User();
            Role role = RoleFactory.CreateRole(1);
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            CommonPermissionConfig config = new CommonPermissionConfig(role, accessObject);

            //给测试的操作设置权限
            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            ICommonPermissionService service = CreateCommonPermissionService(user, config);

            //操作
            CommonPermission permission = service.GetCommonPermission(user, accessObject);

            //验证
            Assert.IsTrue(permission.HavePermission(operation));
            Assert.IsFalse(permission.HavePermission(accessObject.Operations.First(o => o != operation)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommonPermissionService_GetCommonPermission_InvalidAccessObject_Test()
        {
            //初始化
            User user = new User();
            Role role = RoleFactory.CreateRole(1);
            //设置访问对象为范围访问对象
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, true);
            CommonPermissionConfig config = new CommonPermissionConfig(role, accessObject);

            ICommonPermissionService service = CreateCommonPermissionService(user, config);

            //操作
            CommonPermission permission = service.GetCommonPermission(user, accessObject);
        }

        /// <summary>
        /// 根据给定的测试信息创建测试的普通权限服务对象
        /// </summary>
        /// <param name="user">进行权限查询的用户</param>
        /// <param name="config">权限配置对象</param>
        /// <returns>普通权限服务对象</returns>
        private ICommonPermissionService CreateCommonPermissionService(User user, CommonPermissionConfig config)
        {
            //初始化用户角色
            IEnumerable<Role> roles = new Role[] { config.Role };

            //进行权限配置查询的规约
            var pcbRolesSpec = new PermissionConfigBaseRolesSpecification(roles.Select(r => r.Id));
            var pcbAccessObjectSpec = new PermissionConfigBaseAccessObjectSpecification(config.AccessObject.Id);
            ISpecification<CommonPermissionConfig> spec = (pcbRolesSpec & pcbRolesSpec).OfType<CommonPermissionConfig>();

            //角色数据仓库接口Mock对象
            var mockRoleRepository = new Mock<IRoleRepository>();
            mockRoleRepository.Setup(m => m.GetRolesOfUser(user)).Returns(roles);
            mockRoleRepository.Setup(m => m.GetInheritRolesOfRoles(roles)).Returns(roles);
            //权限配置数据仓库接口Mock对象
            var mockCommonPermissionConfigRepository = new Mock<ICommonPermissionConfigRepository>();
            mockCommonPermissionConfigRepository
                .Setup(m => m.FindBy(
                    It.Is<ISpecification<CommonPermissionConfig>>(s =>
                        s.SatisfiedBy().ToString() == spec.SatisfiedBy().ToString())))
                .Returns(new CommonPermissionConfig[] { config });


            ICommonPermissionService service = new CommonPermissionService(
                mockRoleRepository.Object,
                mockCommonPermissionConfigRepository.Object);

            return service;
        }

    }
}
