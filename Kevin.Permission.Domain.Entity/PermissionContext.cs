using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace Kevin.Permission.Domain.Entity
{
    using Mapping;

    public class PermissionContext : DbContext
    {
        public PermissionContext()
            : base("PermissionContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleRelationMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new RoleCategoryMap());
            modelBuilder.Configurations.Add(new RoleInheritRelationMap());
        }

    }
}
