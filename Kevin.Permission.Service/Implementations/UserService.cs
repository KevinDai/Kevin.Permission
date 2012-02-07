using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Service.Implementations
{
    using Kevin.Permission.Domain.Core.Users;
    using Kevin.Permission.Domain.Core.UserRoleRelation;
    using Kevin.Permission.Infrastructure.Model;
    using Kevin.Permission.Service.Interfaces;

    public class UserService : IUserService
    {

        #region Members

        /// <summary>
        /// 统一工作单元
        /// </summary>
        protected IUnitOfWork UnitOfWork
        {
            get;
            private set;
        }

        /// <summary>
        /// 用户数据仓库
        /// </summary>
        protected IUserRepository UserRepository
        {
            get;
            private set;
        }

        /// <summary>
        /// 用户角色关联数据仓库
        /// </summary>
        public IUserRoleRelationService UserRoleRelationService
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public UserService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IUserRoleRelationService userRoleRelationService)
        {
            UnitOfWork = unitOfWork;
            UserRepository = userRepository;
            UserRoleRelationService = userRoleRelationService;
        }

        #endregion

        #region IUserService implementation

        /// <summary>
        /// <see cref="IUserService"/>
        /// </summary>
        /// <param name="specification"><see cref="IUserService"/></param>
        /// <param name="pageIndex"><see cref="IUserService"/></param>
        /// <param name="pageSize"><see cref="IUserService"/></param>
        /// <param name="sortDescriptors"><see cref="IUserService"/></param>
        /// <returns></returns>
        public PageList<User> GetUserPageList(
            ISpecification<User> specification,
            int pageIndex,
            int pageSize,
            params SortDescriptor<User>[] sortDescriptors)
        {
            int totalCount = 0;
            var users = UserRepository.FindPageBy(
                specification,
                pageIndex,
                pageSize,
                out totalCount,
                sortDescriptors);

            var pageList = new PageList<User>(users, pageIndex, pageSize, totalCount);
            return pageList;
        }

        #endregion

    }
}
