using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kevin.Permission.Domain.Core.Test.PermissionServices
{
    using Kevin.Permission.Domain.Core.AccessObjects;
    using Kevin.Permission.Domain.Core.PermissionConfigs;
    using Kevin.Permission.Domain.Core.PermissionServices;
    using Kevin.Permission.Domain.Core.Roles;
    using Kevin.Permission.Domain.Core.Users;
    using Data;

    [TestClass]
    public class CommonPermissionTest
    {
        [TestMethod]
        public void CommonPermission_Constructor_With_PermissionConfigs_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            PermissionConfig config = new PermissionConfig(role, accessObject);

            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            CommonPermission commonPermission = new CommonPermission(
                accessObject,
                new PermissionConfig[] { config });

            //验证
            Assert.AreEqual(accessObject.Operations.Count(), commonPermission.OperationPermissions.Count());
            Assert.AreSame(config, commonPermission.PermissionConfigs.First());
            Assert.IsTrue(commonPermission.HavePermission(operation));
            Assert.IsFalse(commonPermission.HavePermission(
                accessObject.Operations.First(o => o != operation)));
        }

        [TestMethod]
        public void CommonPermission_GetOperationPermission_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            PermissionConfig config = new PermissionConfig(role, accessObject);
            var operation = accessObject.Operations.First();

            CommonPermission commonPermission = new CommonPermission(accessObject);

            //操作
            OperationPermission operationPermission = commonPermission.GetOperationPermission(operation);

            //验证
            Assert.IsNotNull(operationPermission);
            Assert.AreSame(operation, operationPermission.Operation);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommonPermission_GetOperationPermission_InvlidOperation_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            PermissionConfig config = new PermissionConfig(role, accessObject);

            CommonPermission commonPermission = new CommonPermission(accessObject);

            //操作
            OperationPermission operationPermission = commonPermission.GetOperationPermission(new Operation());
        }

        [TestMethod]
        public void CommonPermission_PermissionCalculate_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            PermissionConfig config = new PermissionConfig(role, accessObject);
            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            CommonPermission commonPermission = new CommonPermission(accessObject);

            //操作
            commonPermission.PermissionCalculate(config);

            //验证
            Assert.AreSame(config, commonPermission.PermissionConfigs.First());
            Assert.IsTrue(commonPermission.HavePermission(operation));
            Assert.IsFalse(commonPermission.HavePermission(
                accessObject.Operations.First(o => o != operation)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommonPermission_PermissionCalculate_InvalidConfigAccessObject_Test()
        {
            //初始化
            Role role = new Role();
            AccessObject accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            PermissionConfig config = new PermissionConfig(role, accessObject);
            var operation = accessObject.Operations.First();
            config.SetOperationPermission(operation, true, false);

            CommonPermission commonPermission = new CommonPermission(accessObject);

            //操作
            commonPermission.PermissionCalculate(new PermissionConfig());
        }

    }
}
