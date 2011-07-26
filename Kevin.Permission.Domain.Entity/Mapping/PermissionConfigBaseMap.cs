using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core;

    public class PermissionConfigBaseMap : EntityTypeConfiguration<PermissionConfigBase>
    {
        public PermissionConfigBaseMap()
        {
            this.HasKey(pcb => pcb.Id);

            this.ToTable("PermissionConfigs");

            this.Property(pcb => pcb.Id)
                .HasColumnName("Id");

            this.HasRequired(pcb => pcb.Role)
                .WithMany()
                .Map(fk => fk.MapKey("RoleId"));
            this.HasRequired(pcb => pcb.AccessObject)
                .WithMany()
                .Map(fk => fk.MapKey("AccessObjectId"));

            this.HasMany(pcb => pcb.OperationPermissionConfigs)
                .WithRequired(opc => opc.PermissionConfig);
        }
    }
}
