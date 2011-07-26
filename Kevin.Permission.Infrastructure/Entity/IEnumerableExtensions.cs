using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Infrastructure.Entity
{
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// 锁定集合中的对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objs">对象集合</param>
        /// <returns>锁定后的对象集合</returns>
        public static void Lock<T>(this IEnumerable<T> objs) where T : ILock
        {
            Guidance.ArgumentNotNull(objs, "objs");

            foreach (var item in objs)
            {
                item.Lock();
            }
        }

    }
}
