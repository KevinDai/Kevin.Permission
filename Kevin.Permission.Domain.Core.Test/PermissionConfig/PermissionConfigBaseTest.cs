using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kevin.Permission.Domain.Core.Test
{
    [TestClass]
    public class PermissionConfigBaseTest
    {
        [TestMethod]
        public void PermissionConfigBase_Construct_Test()
        {
            //初始化
            var role = new Role();
            var accessObject = AccessObjectFactory.CreateAcessObject(1, false);

            //操作
            var permissionConfig = new PermissionConfigForTest(role, accessObject);

            //验证
            Assert.AreSame(role, permissionConfig.Role);
            Assert.AreSame(accessObject, permissionConfig.AccessObject);
            Assert.IsNotNull(permissionConfig.OperationPermissionConfigs);
        }

        [TestMethod]
        public void PermissionConfigBase_GetOperationConfig_Test()
        {
            //初始化
            var role = new Role();
            var accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            var permissionConfig = new PermissionConfigForTest(role, accessObject);
            var operation = accessObject.Operations.First();

            //操作
            var operationConfig = permissionConfig.GetOperationConfig(operation);

            //验证
            Assert.IsNotNull(operationConfig);
            Assert.AreEqual(operation, operationConfig.Operation);
        }

        [TestMethod]
        public void PermissionConfigBase_SetOperationPermission_Test()
        {
            //初始化
            var role = new Role();
            var accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            var permissionConfig = new PermissionConfigForTest(role, accessObject);
            var operation = accessObject.Operations.First();

            //操作
            permissionConfig.SetOperationPermission(operation, true, true);
            var permits = permissionConfig.GetSetPermitStatusOperations();
            var denys = permissionConfig.GetSetDenyStatusOperations();

            //验证
            Assert.IsTrue(permits.Any(p => p == operation));
            Assert.IsTrue(denys.Any(p => p == operation));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PermissionConfigBase_SetOperationPermission_Exception_When_InvlidOperation_Test()
        {
            //初始化
            var role = new Role();
            var accessObject = AccessObjectFactory.CreateAcessObject(1, false);
            var permissionConfig = new PermissionConfigForTest(role, accessObject);

            //操作
            permissionConfig.SetOperationPermission(new Operation(), true, true);
        }

    }

    public class PermissionConfigForTest : PermissionConfig
    {
        public PermissionConfigForTest(Role role, AccessObject accessObject)
            : base(role, accessObject)
        {
        }

    }
}
