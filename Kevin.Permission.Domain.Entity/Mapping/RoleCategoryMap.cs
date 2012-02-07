using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core.Roles;

    public class RoleCategoryMap : EntityTypeConfiguration<RoleCategory>
    {
        public RoleCategoryMap()
        {
            this.HasKey(rc => rc.Id);

            this.ToTable("RoleCategorys");

            this.Property(rc => rc.Id)
                .HasColumnName("Id");
            this.Property(rc => rc.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(rc => rc.Code)
                .HasColumnName("Code")
                .HasMaxLength(50);
            this.Property(rc => rc.InheritType)
                .HasColumnName("InheritType")
                .IsRequired();
        }
    }
}
