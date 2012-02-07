using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Entity.Test.AccessObjects
{
    using Kevin.Permission.Domain.Entity.AccessObjects;
    using Kevin.Permission.Domain.Core.AccessObjects;

    [TestClass]
    public class AccessObjectRepositoryTest
    {

        [TestMethod]
        public void AccessObjectRepository_Get_Test()
        {
            var accessObjectId = 1;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var accessObjectRepository = new AccessObjectRepository(unit);

            var result = accessObjectRepository.Get(accessObjectId);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Operations);
            Assert.IsTrue(result.Operations.Count > 0);
            Assert.IsTrue(result.Locked);
        }

        [TestMethod]
        public void AccessObjectRepository_Add_With_Operations_Test()
        {
            var moduleId = 1;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var accessObjectRepository = new AccessObjectRepository(unit);
            var operationRepository = new OperationRepository(unit);
            var moduleRepository = new ModuleRepository(unit);

            using (var ts = new TransactionScope())
            {
                //新增访问对象
                var operations = operationRepository.FindAll().Take(3);
                var module = moduleRepository.Get(moduleId);
                var accessObject = new AccessObject(module, false);

                accessObject.Name = "TestName";
                accessObject.Code = "TestCode";

                foreach (var item in operations)
                {
                    accessObject.Operations.Add(item);
                }
                accessObjectRepository.Add(accessObject);

                //验证添加之后访问对象会处于锁定状态
                Assert.IsTrue(accessObject.Locked);

                unit.SaveChanges();

                //重新查询新增的访问对象
                accessObjectRepository = new AccessObjectRepository(EntityUnitOfWorkFactory.CreateUnitOfWork());
                accessObject = accessObjectRepository.Get(accessObject.Id);

                //验证
                Assert.IsNotNull(accessObject);
                Assert.IsTrue(accessObject.Operations.All(o => operations.Contains(o)));
            }
        }

    }

}
