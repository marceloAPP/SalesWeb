using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exceptions
{
    public class SistemaDbConcurrencyException : ApplicationException
    {
        public SistemaDbConcurrencyException(string message) : base(message) { }
    }
}
