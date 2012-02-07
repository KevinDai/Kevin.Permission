using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core.AccessObjects;

    internal class AccessObjectMap : EntityTypeConfiguration<AccessObject>
    {
        public AccessObjectMap()
        {
            this.HasKey(ao => ao.Id);

            this.ToTable("AccessObjects");

            this.Property(ao => ao.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(ao => ao.Code)
                .HasColumnName("Code")
                .IsRequired()
                .HasMaxLength(50);
            this.Property(ao => ao.RangeAccess)
                .HasColumnName("RangeAccess");

            this.HasRequired(ao => ao.Module)
                .WithMany()
                .Map(fk => fk.MapKey("ModuleId"));

            this.HasMany(ao => ao.Operations)
                .WithMany()
                .Map(cfg =>
                {
                    cfg.MapLeftKey("AccessObjectId");
                    cfg.MapRightKey("OperationId");
                    cfg.ToTable("AccessObjectOperationRelations");
                });
        }
    }
}
