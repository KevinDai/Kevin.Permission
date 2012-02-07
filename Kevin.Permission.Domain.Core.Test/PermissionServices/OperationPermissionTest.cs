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
    public class OperationPermissionTest
    {

        [TestMethod]
        public void PermissionCalculate_PermissionCalculate_Test()
        {
            //初始化
            var operation = OperationFactory.CreateOperation(1);
            var operationPermissionConfig = new OperationPermissionConfig(new PermissionConfig(), operation);

            var operationPermission = new OperationPermission(operation);
            Assert.IsFalse(operationPermission.HavePermission);

            //操作,设置允许权限
            operationPermissionConfig.Permit = true;
            operationPermission.PermissionCalculate(operationPermissionConfig);
            //验证
            Assert.IsTrue(operationPermission.HavePermission);

            //操作，设置拒绝权限
            operationPermissionConfig.Deny = true;
            operationPermission.PermissionCalculate(operationPermissionConfig);
            //验证
            Assert.IsFalse(operationPermission.HavePermission);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PermissionCalculate_PermissionCalculate_InvlidOperationPermissionConfig_Test()
        {
            //初始化
            var operation = OperationFactory.CreateOperation(1);
            var operationPermissionConfig = new OperationPermissionConfig(new PermissionConfig(), new Operation());

            var operationPermission = new OperationPermission(operation);

            //操作,设置允许权限
            operationPermission.PermissionCalculate(operationPermissionConfig);
        }
    }
}
