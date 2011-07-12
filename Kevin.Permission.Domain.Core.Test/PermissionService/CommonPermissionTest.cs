using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kevin.Permission.Domain.Core.Test
{
    [TestClass]
    public class CommonPermissionTest
    {

        [TestMethod]
        public void CommonPermission_Constructor_With_PermissionConfigs_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            CommonPermissionConfig config = new CommonPermissionConfig(role, accessObject);

            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            CommonPermission commonPermission = new CommonPermission(
                accessObject,
                new CommonPermissionConfig[] { config });

            //验证
            Assert.AreEqual(accessObject.Operations.Count(), commonPermission.OperationPermissions.Count());
            Assert.AreSame(config, commonPermission.PermissionConfigs.First());
            Assert.IsTrue(commonPermission.HavePermission(operation));
        }

        [TestMethod]
        public void CommonPermission_PermissionCalculate_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            CommonPermissionConfig config = new CommonPermissionConfig(role, accessObject);
            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            CommonPermission commonPermission = new CommonPermission(accessObject);

            //操作
            commonPermission.PermissionCalculate(config);

            //验证
            Assert.AreSame(config, commonPermission.PermissionConfigs.First());
            Assert.IsTrue(commonPermission.HavePermission(operation));
        }
    }
}
