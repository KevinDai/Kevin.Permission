using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Entity.Test
{
    using Kevin.Permission.Domain.Core;
    using Kevin.Permission.Domain.Entity.UserRoleRelation;
    using Kevin.Permission.Domain.Core.Users;
    using Kevin.Permission.Domain.Core.Roles;

    [TestClass]
    public class UserRoleRelationServiceTest
    {
        [TestMethod]
        public void UserRoleRelationRepository_ClearRelationsOfUser_Test()
        {
            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var userRoleRelationService = new UserRoleRelationService(unit);
            var user = new User() { Id = 1 };

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                userRoleRelationService.ClearRelationsOfUser(user);
                unit.SaveChanges();

                var roles = userRoleRelationService.GetRolesOfUser(user);

                Assert.AreEqual(0, roles.Count());
            }
        }

        [TestMethod]
        public void UserRoleRelationRepository_GetRolesOfUser_Test()
        {
            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var userRoleRelationService = new UserRoleRelationService(unit);
            var user = new User() { Id = 1 };
            var rolesOfUserCount = 2;

            //操作
            var roles = userRoleRelationService.GetRolesOfUser(user);

            //验证
            Assert.AreEqual(rolesOfUserCount, roles.Count());
        }

        [TestMethod]
        public void UserRoleRelationRepository_GetUsersOfRole_Test()
        {
            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var userRoleRelationService = new UserRoleRelationService(unit);
            var role = new Role() { Id = 1 };
            var usersOfRoleCount = 4;

            //操作
            var users = userRoleRelationService.GetUsersOfRole(role);

            //验证
            Assert.AreEqual(usersOfRoleCount, users.Count());
        }

    }
}
