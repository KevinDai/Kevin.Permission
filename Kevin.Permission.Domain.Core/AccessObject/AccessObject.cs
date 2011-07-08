using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;

namespace Kevin.Permission.Domain.Core
{
    /// <summary>
    /// 权限的访问对象类
    /// </summary>
    public class AccessObject : EntityBase<int>, IAggregateRoot
    {
        #region Members

        /// <summary>
        /// 所属模块
        /// </summary>
        public Module Module
        {
            get;
            set;
        }

        /// <summary>
        /// 访问对象名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 访问对象编码
        /// </summary>
        public string Code
        {
            get;
            set;
        }

        /// <summary>
        /// 访问对象的操作权限列表
        /// </summary>
        public ICollection<Operation> Operations
        {
            get
            {
                return _operations;
            }
            protected set
            {
                _operations = value;
            }
        }
        private ICollection<Operation> _operations;

        #endregion

        #region Constructor

        public AccessObject()
        {
            _operations = new List<Operation>();
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain.Validate"/>
        /// </summary>
        protected override void Validate()
        {
        }

        #endregion
    }
}
