using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcContrib.Pagination;

namespace Kevin.Permission.Web.Models
{
    using Kevin.Permission.Domain.Core;
    using Kevin.Permission.Domain.Core.Users;

    public class UserListViewModel
    {
        public CustomPagination<User> Users
        {
            get;
            set;
        }
    }
}