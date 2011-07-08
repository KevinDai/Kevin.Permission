using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            private set;
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
        /// 是否为范围访问对象
        /// </summary>
        public bool RangeAccess
        {
            get;
            private set;
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
            private set
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

        public AccessObject(Module module, bool rangeAcess)
            : this()
        {
            if (module == null)
            {
                throw new ArgumentNullException("module");
            }
            Module = module;
            RangeAccess = rangeAcess;
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain.Validate"/>
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                AddBrokenRule(new BusinessRule("Name", "必须输入访问对象名称"));
            }
            if (string.IsNullOrEmpty(Code))
            {
                AddBrokenRule(new BusinessRule("Code", "必须输入访问对象编码"));
            }
            if (Module == null)
            {
                AddBrokenRule(new BusinessRule("Module", "必须设置有效的模块对象"));
            }
            if (Operations == null || Operations.Count == 0)
            {
                AddBrokenRule(new BusinessRule("Operations", "必须添加有效的操作对象"));
            }
        }

        #endregion
    }
}
