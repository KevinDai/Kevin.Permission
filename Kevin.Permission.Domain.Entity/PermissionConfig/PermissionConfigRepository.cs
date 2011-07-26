using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kevin.Infrastructure.Domain;
using Kevin.Infrastructure.Domain.EntityFramework;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;
    using Kevin.Permission.Infrastructure.Entity;

    /// <summary>
    /// 操作权限配置书库仓库类
    /// </summary>
    public class PermissionConfigRepository
        : Repository<PermissionConfig, int>, IPermissionConfigRepository
    {

        #region Constructor

        public PermissionConfigRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Repository override

        protected override IQueryable<PermissionConfig> Query
        {
            get
            {
                var query = base.Query;
                query = query
                    .Include(cpc => cpc.AccessObject.Operations)
                    .Include(cpc => cpc.Role)
                    .Include(cpc => cpc.OperationPermissionConfigs);
                return query;
            }
        }

        #endregion

    }
}
