using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    public class RoleRepository : Repository<Role, int>, IRoleRepository
    {

        #region Constructor

        public RoleRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Repository override

        protected override IEnumerable<string> Paths
        {
            get
            {
                return new string[] { "Category" };
            }
        }

        #endregion

        #region IRoleRepository implementation

        public IEnumerable<Role> GetRolesOfUser(User user)
        {
            throw new NotImplementedException();
        }

        public void AddInheritRoleOfRole(Role role, Role inheritRole)
        {
            throw new NotImplementedException();
        }

        public void RemoveInheritRoleOfRole(Role role, Role inheritRole)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetInheritRolesOfRole(Role role, bool cascade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetDeriveRolesOfRole(Role role, bool cascade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Role> GetInheritRolesOfRoles(IEnumerable<Role> roles)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
