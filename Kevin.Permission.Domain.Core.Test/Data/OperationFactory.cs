using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kevin.Permission.Domain.Core.Test
{
    public static class OperationFactory
    {
        public static Operation CreateOperation(int id)
        {
            return new Operation()
            {
                Id = id,
                Name = "Operation" + id.ToString(),
                Code = "Operation" + id.ToString()
            };
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
