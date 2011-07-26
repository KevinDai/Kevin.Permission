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
    /// 权限的访问对象数据仓库类
    /// </summary>
    public class AccessObjectRepository : Repository<AccessObject, int>, IAccessObjectRepository
    {

        #region Members


        #endregion

        #region Constructor

        public AccessObjectRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region Repository override

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        protected override IQueryable<AccessObject> Query
        {
            get
            {
                var query = base.Query;
                query = query
                    .Include(ao => ao.Module)
                    .Include(ao => ao.Operations);
                return query;
            }
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="entity"><see cref="Repository{AccessObject,int}"/></param>
        public override void Add(AccessObject entity)
        {
            base.Add(entity);
            entity.Lock();
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="entity"><see cref="Repository{AccessObject,int}"/></param>
        public override void Update(AccessObject entity)
        {
            base.Update(entity);
            entity.Lock();
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="id"><see cref="Repository{AccessObject,int}"/></param>
        /// <returns></returns>
        public override AccessObject Get(int id)
        {
            var entity = base.Get(id);
            entity.Lock();
            return entity;
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="sortDescriptors"><see cref="Repository{AccessObject,int}"/></param>
        /// <returns><see cref="Repository{AccessObject,int}"/></returns>
        public override IEnumerable<AccessObject> FindAll(params SortDescriptor<AccessObject>[] sortDescriptors)
        {
            var result = base.FindAll(sortDescriptors);
            result.Lock();
            return result;
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="specification"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="sortDescriptors"><see cref="Repository{AccessObject,int}"/></param>
        /// <returns><see cref="Repository{AccessObject,int}"/></returns>
        public override IEnumerable<AccessObject> FindBy(
            ISpecification<AccessObject> specification,
            params SortDescriptor<AccessObject>[] sortDescriptors)
        {
            var result = base.FindBy(specification, sortDescriptors);
            result.Lock();
            return result;
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="specification"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="pageIndex"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="pageCount"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="totalCount"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="sortDescriptors"><see cref="Repository{AccessObject,int}"/></param>
        /// <returns><see cref="Repository{AccessObject,int}"/></returns>
        public override IEnumerable<AccessObject> FindPageBy(
            ISpecification<AccessObject> specification,
            int pageIndex,
            int pageCount,
            out int totalCount,
            params SortDescriptor<AccessObject>[] sortDescriptors)
        {
            var result = base.FindPageBy(specification, pageIndex, pageCount, out totalCount, sortDescriptors);
            result.Lock();
            return result;
        }

        /// <summary>
        /// <see cref="Repository{AccessObject,int}"/>
        /// </summary>
        /// <param name="specification"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="pageIndex"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="pageCount"><see cref="Repository{AccessObject,int}"/></param>
        /// <param name="sortDescriptors"><see cref="Repository{AccessObject,int}"/></param>
        /// <returns><see cref="Repository{AccessObject,int}"/></returns>
        public override IEnumerable<AccessObject> FindPageBy(
            ISpecification<AccessObject> specification,
            int pageIndex,
            int pageCount,
            params SortDescriptor<AccessObject>[] sortDescriptors)
        {
            var result = base.FindPageBy(specification, pageIndex, pageCount, sortDescriptors);
            result.Lock();
            return result;
        }

        #endregion

    }
}