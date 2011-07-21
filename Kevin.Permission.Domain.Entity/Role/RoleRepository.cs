using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    /// <summary>
    /// 角色数据仓库类
    /// </summary>
    public class RoleRepository : Repository<Role, int>, IRoleRepository
    {

        #region Constructor

        public RoleRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Repository override

        /// <summary>
        /// <see cref="Repository{Role, int}"/>
        /// </summary>
        protected override IQueryable<Role> Query
        {
            get
            {
                var query = base.Query.Include(r => r.Category);
                return query;
            }
        }

        #endregion

        #region IRoleRepository implementation


        #endregion
    }

}
