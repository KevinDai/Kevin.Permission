using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core;

    public class OperationMap : EntityTypeConfiguration<Operation>
    {
        public OperationMap()
        {
            this.HasKey(o => o.Id);

            this.ToTable("Operations");

            this.Property(o => o.Id)
                .HasColumnName("Id");
            this.Property(o => o.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(o => o.Code)
                .HasColumnName("Code")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
