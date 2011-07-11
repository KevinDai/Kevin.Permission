﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Kevin.Infrastructure.Domain.Specification;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 根据权限配置设置的访问对象进行筛选的规约类
    /// </summary>
    public class PermissionConfigBaseAccessObjectSpecification : Specification<PermissionConfigBase>
    {

        #region Members

        /// <summary>
        /// 访问对象标识符
        /// </summary>
        public int AccessObjectId
        {
            get;
            private set;
        }

        #endregion

        #region Constructor

        public PermissionConfigBaseAccessObjectSpecification(int accessObjectId)
        {
            AccessObjectId = accessObjectId;
        }

        #endregion

        #region Specification<PermisssionConfigBase> implementation

        public override Expression<Func<PermissionConfigBase, bool>> SatisfiedBy()
        {
            return p => p.AccessObject.Id == AccessObjectId;
        }

        #endregion
    }
}
