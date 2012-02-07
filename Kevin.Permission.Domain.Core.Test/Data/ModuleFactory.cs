using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core.Test.Data
{
    using Kevin.Permission.Domain.Core.AccessObjects;

    public static class ModuleFactory
    {
        public static Module CreateModule(int id)
        {
            var module = new Module();
            module.Id = id;
            module.Name = "TestName";
            module.Code = "TestCode";
            return module;
        }
    }
}
