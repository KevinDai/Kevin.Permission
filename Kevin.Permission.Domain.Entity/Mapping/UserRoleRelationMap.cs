using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.ModelConfiguration;

namespace Kevin.Permission.Domain.Entity.Mapping
{
    using Kevin.Permission.Domain.Core;

    public class UserRoleRelationMap : EntityTypeConfiguration<UserRoleRelation>
    {
        public UserRoleRelationMap()
        {
            this.HasKey(urr => urr.Id);

            this.HasRequired(urr => urr.Role)
                .WithMany()
                .Map(fk => fk.MapKey("RoleId"));
            this.HasRequired(urr => urr.User)
                .WithMany()
                .Map(fk => fk.MapKey("UserId"));
        }
    }
}
