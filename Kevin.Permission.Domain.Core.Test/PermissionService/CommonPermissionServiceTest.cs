using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core.Test
{
    [TestClass]
    public class CommonPermissionServiceTest
    {

        [TestMethod]
        public void CommonPermissionService_HavePermission_Test()
        {
            //初始化
            User user = new User();
            Role role = RoleFactory.CreateRole(1);
            IEnumerable<Role> roles = new Role[] { role };

            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            CommonPermissionConfig config = new CommonPermissionConfig(role, accessObject);
            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            //进行权限配置查询的规约
            var pcbRolesSpec = new PermissionConfigBaseRolesSpecification(roles.Select(r => r.Id));
            var pcbAccessObjectSpec = new PermissionConfigBaseAccessObjectSpecification(accessObject.Id);
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

            //操作
            bool result = service.HavePermission(user, accessObject, operation);

            //验证
            Assert.IsTrue(result);
        }

    }
}
