using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core.Test
{
    public static class AccessObjectFactory
    {
        public static AccessObject CreateAcessObject(int id, bool rangeAccess)
        {
            var accessObject = new AccessObject(ModuleFactory.CreateModule(1), rangeAccess);

            accessObject.Id = id;
            accessObject.Name = "TestAccessObject";
            accessObject.Code = "TestAccessObject";

            foreach (var operation in CreateOperations())
            {
                accessObject.Operations.Add(operation);
            }

            return accessObject;
        }

        public static IEnumerable<Operation> CreateOperations()
        {
            var list = new List<Operation>();
            for (var i = 1; i < 4; i++)
            {
                list.Add(new Operation()
                {
                    Id = i,
                    Name = "Operation" + i.ToString(),
                    Code = "Operation" + i.ToString()
                });
            }
            return list;
        }
    }
}
