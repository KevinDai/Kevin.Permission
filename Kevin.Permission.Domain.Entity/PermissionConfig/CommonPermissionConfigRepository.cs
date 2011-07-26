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
    public class CommonPermissionConfigRepository
        : Repository<CommonPermissionConfig, int>, ICommonPermissionConfigRepository
    {

        #region Constructor

        public CommonPermissionConfigRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Repository override

        protected override IQueryable<CommonPermissionConfig> Query
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
