using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core;

    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(r => r.Id);

            this.ToTable("Roles");

            this.Property(r => r.Id)
                .HasColumnName("Id");
            this.Property(r => r.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(r => r.Code)
                .HasColumnName("Id")
                .HasMaxLength(50);

            this.HasRequired(r => r.Category)
                .WithMany()
                .Map(fk => fk.MapKey("RoleCategoryId"));

        }
    }
}
