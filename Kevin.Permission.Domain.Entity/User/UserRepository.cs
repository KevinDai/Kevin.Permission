using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

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

        /// <summary>
        /// <see cref="IUserRepository"/>
        /// </summary>
        /// <param name="role"><see cref="IUserRepository"/></param>
        /// <returns><see cref="IUserRepository"/></returns>
        public IEnumerable<User> GetUsersOfRole(Role role)
        {
            Guidance.ArgumentNotNull(role, "role");

            var userRoleRelationQuery = this.UnitOfWork.DbSet<UserRoleRelation, int>();
            var users = userRoleRelationQuery
                .Where(urr => urr.Role.Id == role.Id)
                .Select(urr => urr.User);

            return users;
        }

        #endregion

    }
}
