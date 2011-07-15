using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace Kevin.Permission.Domain.Entity
{
    using Map;

    public class PermissionContext : DbContext
    {
        public PermissionContext()
            : base("PermissionContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }

    }
}
