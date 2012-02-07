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
    using Kevin.Permission.Domain.Core.Users;
    using Kevin.Permission.Domain.Entity.Users;

    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void UserRepository_Add_Test()
        {
            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                //初始化
                var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
                var userRepository = new UserRepository(unit);
                var user = new User()
                {
                    Name = "TestUserName",
                };

                //新增用户
                userRepository.Add(user);
                unit.SaveChanges();

                //创建新的工作单元进行查询，查询前面新增的用户是否存在
                userRepository = new UserRepository(EntityUnitOfWorkFactory.CreateUnitOfWork());
                var result = userRepository.Get(user.Id);

                //验证
                Assert.IsNotNull(result);
                Assert.AreEqual(user, result);
            }
        }

        [TestMethod]
        public void UserRepository_Update_Test()
        {
            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                var id = 1;
                var expectCode = "TestCode";
                //初始化
                var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
                var userRepository = new UserRepository(unit);
                var user = userRepository.Get(id);

                //更新用编码
                user.Code = expectCode;
                userRepository.Update(user);
                unit.SaveChanges();

                //重新获取用户
                userRepository = new UserRepository(EntityUnitOfWorkFactory.CreateUnitOfWork());
                user = userRepository.Get(id);

                //验证
                Assert.AreEqual(expectCode, user.Code);
            }
        }

        [TestMethod]
        public void UserRepository_Remove_Test()
        {
            //启动事务进行测试，并不提交
            using (var ts = new TransactionScope())
            {
                var id = 1;
                //初始化
                var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
                var userRepository = new UserRepository(unit);
                var user = userRepository.Get(id);

                //删除用户
                userRepository.Remove(user);
                unit.SaveChanges();

                //重新获取用户
                userRepository = new UserRepository(EntityUnitOfWorkFactory.CreateUnitOfWork());
                user = userRepository.Get(id);

                //验证
                Assert.IsNull(user);
            }
        }

        [TestMethod]
        public void UserRepository_FindBy_Sort_Test()
        {
            //初始化
            var unit = EntityUnitOfWorkFactory.CreateUnitOfWork();
            var userRepository = new UserRepository(unit);

            //查询
            var sortDescriptor = new SortDescriptor<User>(u => u.Name);
            var users = userRepository.FindAll(sortDescriptor).ToArray();

            //验证
            for (int i = 0; i < users.Length - 2; i++)
            {
                Assert.IsTrue(users[i].Name.CompareTo(users[i + 1].Name) <= 0);
            }
        }

    }
}
