using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Kevin.Permission.Infrastructure
{
    public static class Guidance
    {
        /// <summary>
        /// 参数对象是否为空的验证
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="argName">参数名称</param>
        /// <param name="msg">异常消息</param>
        public static void ArgumentNotNull<T>(T obj, string argName, string msg = "")
            where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(argName, msg);
            }
        }

        /// <summary>
        /// 验证对象列表非空
        /// </summary>
        /// <typeparam name="T">对象列表类型</typeparam>
        /// <param name="list">对象列表</param>
        /// <param name="argName">参数名称</param>
        /// <param name="msg">异常消息</param>
        public static void IEnumerableNotNull<T>(IEnumerable<T> list, string argName, string msg = "")
        {
            if (list == null
                ||
                !list.Any())
            {
                throw new ArgumentException(msg, argName);
            }
        }
    }
}
