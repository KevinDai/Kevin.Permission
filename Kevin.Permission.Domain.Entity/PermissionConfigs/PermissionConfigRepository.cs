using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Kevin.Infrastructure.Domain;
using Kevin.Infrastructure.Domain.EntityFramework;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Entity.PermissionConfigs
{
    using Kevin.Permission.Domain.Core.PermissionConfigs;
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

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        protected override IQueryable<PermissionConfig> Query
        {
            get
            {
                var query = base.Query;
                query = query
                    .Include(cpc => cpc.AccessObject)
                    .Include(cpc => cpc.Role)
                    .Include(cpc => cpc.OperationPermissionConfigs);
                return query;
            }
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="entity"><see cref="Repository{PermissionConfig,int}"/></param>
        public override void Add(PermissionConfig entity)
        {
            base.Add(entity);
            entity.Lock();
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="entity"><see cref="Repository{PermissionConfig,int}"/></param>
        public override void Update(PermissionConfig entity)
        {
            base.Update(entity);
            entity.Lock();
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="id"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <returns><see cref="Repository{PermissionConfig,int}"/></returns>
        public override PermissionConfig Get(int id)
        {
            var entity = base.Get(id);
            entity.Lock();
            return entity;
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="sortDescriptors"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <returns><see cref="Repository{PermissionConfig,int}"/></returns>
        public override IEnumerable<PermissionConfig> FindAll(params SortDescriptor<PermissionConfig>[] sortDescriptors)
        {
            var result = base.FindAll(sortDescriptors);
            result.Lock();
            return result;
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="specification"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="sortDescriptors"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <returns><see cref="Repository{PermissionConfig,int}"/></returns>
        public override IEnumerable<PermissionConfig> FindBy(
            ISpecification<PermissionConfig> specification, 
            params SortDescriptor<PermissionConfig>[] sortDescriptors)
        {
            var result = base.FindBy(specification, sortDescriptors);
            result.Lock();
            return result;
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="specification"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="pageIndex"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="pageSize"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="totalCount"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="sortDescriptors"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <returns><see cref="Repository{PermissionConfig,int}"/></returns>
        public override IEnumerable<PermissionConfig> FindPageBy(
            ISpecification<PermissionConfig> specification, 
            int pageIndex, 
            int pageSize, 
            out int totalCount, 
            params SortDescriptor<PermissionConfig>[] sortDescriptors)
        {
            var result = base.FindPageBy(specification, pageIndex, pageSize, out totalCount, sortDescriptors);
            result.Lock();
            return result;
        }

        /// <summary>
        /// <see cref="Repository{PermissionConfig,int}"/>
        /// </summary>
        /// <param name="specification"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="pageIndex"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="pageSize"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <param name="sortDescriptors"><see cref="Repository{PermissionConfig,int}"/></param>
        /// <returns><see cref="Repository{PermissionConfig,int}"/></returns>
        public override IEnumerable<PermissionConfig> FindPageBy(
            ISpecification<PermissionConfig> specification,
            int pageIndex,
            int pageSize,
            params SortDescriptor<PermissionConfig>[] sortDescriptors)
        {
            var result = base.FindPageBy(specification, pageIndex, pageSize, sortDescriptors);
            result.Lock();
            return result;
        }

        #endregion

    }
}
