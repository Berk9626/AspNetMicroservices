using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    public class NotFoundExceptions: ApplicationException
    {
        public NotFoundExceptions(string name, object key)
           : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }

    }
}
