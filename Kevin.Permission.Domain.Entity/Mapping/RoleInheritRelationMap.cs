using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;


namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Entity.Roles;

    internal class RoleInheritRelationMap : EntityTypeConfiguration<RoleInheritRelation>
    {
        public RoleInheritRelationMap()
        {
            this.HasKey(ri => ri.Id);

            this.ToTable("RoleInheritRelations");

            this.Property(ri => ri.Id)
                .HasColumnName("Id");

            this.HasRequired(ri => ri.Role)
                .WithMany()
                .Map(fk => fk.MapKey("RoleId"));
            this.HasRequired(ri => ri.InheritRole)
                .WithMany()
                .Map(fk => fk.MapKey("InheritRoleId"));
        }
    }
}
