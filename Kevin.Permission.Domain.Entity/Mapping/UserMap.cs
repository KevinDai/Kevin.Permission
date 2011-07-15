using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Map
{
    using Kevin.Permission.Domain.Core;

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(t => t.Id);

            this.ToTable("Users");

            this.Property(u => u.Id)
                .HasColumnName("Id");
            this.Property(u => u.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(u => u.Code)
                .HasColumnName("Code")
                .HasMaxLength(50);
        }
    }
}
