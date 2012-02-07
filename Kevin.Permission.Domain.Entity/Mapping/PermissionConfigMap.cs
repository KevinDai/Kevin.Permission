using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core.PermissionConfigs;

    public class PermissionConfigMap : EntityTypeConfiguration<PermissionConfig>
    {
        public PermissionConfigMap()
        {
            this.HasKey(pc => pc.Id);

            this.ToTable("PermissionConfigs");

            this.Property(pc => pc.Id)
                .HasColumnName("Id");

            this.HasRequired(pc => pc.Role)
                .WithMany()
                .Map(fk => fk.MapKey("RoleId"));
            this.HasRequired(pc => pc.AccessObject)
                .WithMany()
                .Map(fk => fk.MapKey("AccessObjectId"));
        }
    }
}
