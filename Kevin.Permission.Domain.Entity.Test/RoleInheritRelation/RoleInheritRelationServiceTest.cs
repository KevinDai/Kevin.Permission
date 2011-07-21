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
    using Kevin.Permission.Domain.Entity.Resource;

    [TestClass]
    public class RoleInheritRelationServiceTest
    {
        [TestMethod]
        public void RoleInheritRelationService_AddRelation_Test()
        {
            var roleId = 3;
            var inheritRoleId = 4;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRole = roleRepository.Get(inheritRoleId);

            var inheritRoles = roleInheritRelationService.GetInheritRolesOfRole(role, false);
            Assert.IsFalse(inheritRoles.Contains(inheritRole));

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.AddRelation(role, inheritRole);
                unit.SaveChanges();

                inheritRoles = roleInheritRelationService.GetInheritRolesOfRole(role, false);
                Assert.IsTrue(inheritRoles.Contains(inheritRole));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoleInheritRelationService_AddRelation_InheritSelf_Test()
        {
            var roleId = 3;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.AddRelation(role, role);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoleInheritRelationService_AddRelation_NotInheritRoleCategory_Test()
        {
            var roleId = 14;
            var inheritRoleId = 15;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRole = roleRepository.Get(inheritRoleId);

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.AddRelation(role, inheritRole);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoleInheritRelationService_AddRelation_CycleInherit_Test()
        {
            var roleId = 2;
            var inheritRoleId = 3;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRole = roleRepository.Get(inheritRoleId);

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.AddRelation(role, inheritRole);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoleInheritRelationService_AddRelation_DifferentCategoryRole_Test()
        {
            var roleId = 3;
            var inheritRoleId = 7;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRole = roleRepository.Get(inheritRoleId);

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.AddRelation(role, inheritRole);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoleInheritRelationService_AddRelation_SingleInheritRole_MuiltInherit_Test()
        {
            var roleId = 8;
            var inheritRoleId = 12;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRole = roleRepository.Get(inheritRoleId);

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.AddRelation(role, inheritRole);
            }
        }

        [TestMethod]
        public void RoleInheritRelationService_RemoveRelation_Test()
        {
            var roleId = 3;


            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRoles = roleInheritRelationService.GetInheritRolesOfRole(role, false);
            var inheritRole = inheritRoles.First();

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.RemoveRelation(role, inheritRole);
                unit.SaveChanges();

                inheritRoles = roleInheritRelationService.GetInheritRolesOfRole(role, false);
                Assert.IsFalse(inheritRoles.Contains(inheritRole));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoleInheritRelationService_RemoveRelation_NotExistRelation_Test()
        {
            var roleId = 5;
            var inheritRoleId = 4;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var roleInheritRelationService = new RoleInheritRelationService(unit);
            var roleRepository = new RoleRepository(unit);

            var role = roleRepository.Get(roleId);
            var inheritRole = roleRepository.Get(inheritRoleId);

            var inheritRoles = roleInheritRelationService.GetInheritRolesOfRole(role, false);
            Assert.IsFalse(inheritRoles.Contains(inheritRole));

            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                roleInheritRelationService.RemoveRelation(role, inheritRole);
            }
        }
    }
}
