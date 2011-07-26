using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core;

    public class ModuleMap : EntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {
            this.HasKey(m => m.Id);

            this.ToTable("Modules");

            this.Property(m => m.Id)
                .HasColumnName("Id");
            this.Property(m => m.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(m => m.Code)
                .HasColumnName("Code")
                .IsRequired()
                .HasMaxLength(50);
        }

    }
}
