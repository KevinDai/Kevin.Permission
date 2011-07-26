using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain.EntityFramework;

namespace Kevin.Permission.Domain.Entity
{
    using Kevin.Permission.Domain.Core;

    /// <summary>
    /// 模块信息数据仓库类
    /// </summary>
    public class ModuleRepository
        : Repository<Module, int>, IModuleRepository
    {

        #region Constructor

        public ModuleRepository(IEntityUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

    }
}
