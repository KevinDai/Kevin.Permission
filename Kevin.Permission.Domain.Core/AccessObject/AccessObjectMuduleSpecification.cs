using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 根据所属模块筛选访问对象的规约类
    /// </summary>
    public class AccessObjectModuleSpecification : Specification<AccessObject>
    {
        #region Members

        /// <summary>
        /// 模块信息对象标识符
        /// </summary>
        public int ModuleId
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public AccessObjectModuleSpecification(int moduleId)
        {
            ModuleId = moduleId;
        }

        #endregion

        #region Specification<Role> implementation

        public override Expression<Func<AccessObject, bool>> SatisfiedBy()
        {
            return a => a.Module.Id == ModuleId;
        }

        #endregion
    }
}
