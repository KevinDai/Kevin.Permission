using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity.Users
{
    using Kevin.Permission.Domain.Core.Users;

    /// <summary>
    /// 用户数据仓库类
    /// </summary>
    public class UserRepository : Repository<User, int>, IUserRepository
    {

        #region Constructor

        public UserRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region IUserRepository implementation

        #endregion

    }
}
