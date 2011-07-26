using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Entity.Test.PermissionConfig
{
    using Kevin.Permission.Domain.Core;

    [TestClass]
    public class CommonPermissionConfigRepositoryTest
    {

        [TestMethod]
        public void CommonPermissionConfigRepository_Get_Test()
        {
            var configId = 1;

            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var commonPermissionConfigRepository = new CommonPermissionConfigRepository(unit);

            var config = commonPermissionConfigRepository.Get(configId);
        }

    }
}
