using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity.Test
{
    using Kevin.Permission.Domain.Entity;

    public static class EntityUnitOfWorkFactory
    {
        public static IEntityUnitOfWork CreateUnitOfWork()
        {
            var context = new PermissionContext();
            return new EntityUnitOfWork(context);
        }
    }
}
