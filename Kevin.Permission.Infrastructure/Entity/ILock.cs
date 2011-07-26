using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Infrastructure.Entity
{

    /// <summary>
    /// 实体状态的锁定接口
    /// 由于Entity在映射实体包含的集合属性事，只能使用ICollection接口的集合对象，
    /// 但有些情况下集合是不允许更新，因此使用该接口锁定实体，
    /// 使用如果比较流畅则以后提取为基础框架一部分
    /// </summary>
    public interface ILock
    {
        void Lock();
        bool Locked
        {
            get;
        }
    }
}
