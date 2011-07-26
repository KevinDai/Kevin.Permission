using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core;

    public class OperationPermissionConfigMap : EntityTypeConfiguration<OperationPermissionConfig>
    {
        public OperationPermissionConfigMap()
        {
            this.HasKey(opc => opc.Id);

            this.ToTable("OperationPermissionConfigs");

            this.Property(opc => opc.Id)
                .HasColumnName("Id");
            this.Property(opc => opc.Permit)
                .HasColumnName("Permit");
            this.Property(opc => opc.Deny)
                .HasColumnName("Deny");

            this.HasRequired(opc => opc.Operation)
                .WithMany()
                .Map(fk => fk.MapKey("OperationId"));
            this.HasRequired(opc => opc.PermissionConfig)
                .WithMany()
                .Map(fk => fk.MapKey("PermissionConfigId"));
        }

    }
}
