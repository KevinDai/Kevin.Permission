using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Kevin.Infrastructure.Domain;
using System.Runtime.CompilerServices;

namespace Kevin.Permission.Domain.Core
{
    using Kevin.Permission.Infrastructure;
    using Kevin.Permission.Infrastructure.Entity;

    /// <summary>
    /// 权限的访问对象类
    /// </summary>
    public class AccessObject : EntityBase<int>, IAggregateRoot, ILock
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
                if (_locked)
                {
                    return _readOnlyOpeartions;
                }
                else
                {
                    return _operations;
                }
            }
        }
        private ReadOnlyCollection<Operation> _readOnlyOpeartions;
        private IList<Operation> _operations;

        #endregion

        #region Constructor

        public AccessObject()
        {
            _operations = new List<Operation>();
            _readOnlyOpeartions = new ReadOnlyCollection<Operation>(_operations);
        }

        public AccessObject(Module module, bool rangeAcess)
            : this()
        {
            Guidance.ArgumentNotNull(module, "module");

            Module = module;
            RangeAccess = rangeAcess;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 判断访问对象是否包含指定的操作
        /// </summary>
        /// <param name="operation">操作</param>
        /// <returns>是否包含操作</returns>
        public bool Contains(Operation operation)
        {
            return Operations.Any(o => o.Id == operation.Id);
        }

        /// <summary>
        /// 获取访问对象中的指定操作
        /// </summary>
        /// <param name="operationId">操作标识符</param>
        /// <returns>操作</returns>
        public Operation GetOperation(int operationId)
        {
            return Operations.FirstOrDefault(o => o.Id == operationId);
        }

        #endregion

        #region EntityBase<int> override

        /// <summary>
        /// <see cref="Kevin.Infrastructure.Domain"/>
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

        #region ILock implementation

        /// <summary>
        /// <see cref="ILock"/>
        /// </summary>
        public void Lock()
        {
            _locked = true;
        }

        /// <summary>
        /// <see cref="ILock"/>
        /// </summary>
        public bool Locked
        {
            get
            {
                return _locked;
            }
        }
        private bool _locked = false;

        #endregion
    }
}
