using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core.Test.Data
{
    using Kevin.Permission.Domain.Core.Roles;

    public class RoleFactory
    {
        public static Role CreateRole(int id)
        {
            var role = new Role(CreateRoleCategory(1));
            role.Id = id;
            role.Name = "TestRoleName";
            role.Code = "TestRoleCode";
            return role;
        }

        public static RoleCategory CreateRoleCategory(int id)
        {
            var category = new RoleCategory(RoleInheritType.NotInherit);
            category.Id = id;
            category.Name = "TestRoleCategoryName";
            category.Code = "TestRoleCategoryCode";
            return category;
        }
    }
}
