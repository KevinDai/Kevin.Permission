using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    public class RoleCategoryRepository
        : Repository<RoleCategory, int>, IRoleCategoryRepository
    {
        #region Constructor

        public RoleCategoryRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}
