using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    public class OperationRepository
        : Repository<Operation, int>, IOperationRepository
    {

        #region Constructor

        public OperationRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

    }
}
