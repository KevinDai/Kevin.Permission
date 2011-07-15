using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    public class UserRoleRelationRepository 
        : Repository<UserRoleRelation, int>, IUserRoleRelationRepository
    {
        
        #region Constructor

        public UserRoleRelationRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region IUserRoleRelationRepository implementation

        public void ClearRelationsOfUser(User user)
        {
            throw new NotImplementedException();
        }

        public void ClearRelationsOfRole(Role role)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
