using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kevin.Permission.Domain.Core.Test.PermissionServices
{
    using Data;
    using Kevin.Permission.Domain.Core.AccessObjects;
    using Kevin.Permission.Domain.Core.PermissionConfigs;
    using Kevin.Permission.Domain.Core.PermissionServices;
    using Kevin.Permission.Domain.Core.Roles;
    using Kevin.Permission.Domain.Core.Users;
    using Kevin.Permission.Domain.Core.UserRoleRelation;

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
            PermissionConfig config = new PermissionConfig(role, accessObject);

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
            PermissionConfig config = new PermissionConfig(role, accessObject);

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
        private ICommonPermissionService CreateCommonPermissionService(User user, PermissionConfig config)
        {
            //初始化用户角色
            IEnumerable<Role> roles = new Role[] { config.Role };

            //进行权限配置查询的规约
            var pcbRolesSpec = new PermissionConfigBaseRolesSpecification(roles.Select(r => r.Id));
            var pcbAccessObjectSpec = new PermissionConfigBaseAccessObjectSpecification(config.AccessObject.Id);
            ISpecification<PermissionConfig> spec = pcbRolesSpec & pcbRolesSpec;

            var mockUserRoleRelationService = new Mock<IUserRoleRelationService>();
            mockUserRoleRelationService.Setup(m => m.GetRolesOfUser(user)).Returns(roles);

            var mockRoleInheritRelationService = new Mock<IRoleInheritRelationService>();
            mockRoleInheritRelationService.Setup(m => m.GetInheritRolesOfRoles(roles)).Returns(new Role[] { });

            //权限配置数据仓库接口Mock对象
            var mockPermissionConfigRepository = new Mock<IPermissionConfigRepository>();
            mockPermissionConfigRepository
                .Setup(m => m.FindBy(
                    It.Is<ISpecification<PermissionConfig>>(s =>
                        s.SatisfiedBy().ToString() == spec.SatisfiedBy().ToString())))
                .Returns(new PermissionConfig[] { config });


            ICommonPermissionService service = new CommonPermissionService(
                mockUserRoleRelationService.Object,
                mockRoleInheritRelationService.Object,
                mockPermissionConfigRepository.Object);

            return service;
        }

    }
}
