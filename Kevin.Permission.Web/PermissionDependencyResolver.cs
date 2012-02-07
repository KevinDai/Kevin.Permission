using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Kevin.Infrastructure.IoC;

namespace Kevin.Permission.Infrastructure.MVC
{
    public class CommonDependencyResolver : IDependencyResolver
    {
        #region Members

        #endregion

        #region IDependencyResolver implementation

        /// <summary>
        /// <see cref="IDependencyResolver"/>
        /// </summary>
        /// <param name="serviceType"><see cref="IDependencyResolver"/></param>
        /// <returns><see cref="IDependencyResolver"/></returns>
        public object GetService(Type serviceType)
        {
            return IoCFactory.CurrentContainer.GetService(serviceType);
        }

        /// <summary>
        /// <see cref="IDependencyResolver"/>
        /// </summary>
        /// <param name="serviceType"><see cref="IDependencyResolver"/></param>
        /// <returns><see cref="IDependencyResolver"/></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return IoCFactory.CurrentContainer.GetServices(serviceType);
        }

        #endregion
    }
}
