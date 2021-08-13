using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class SistemaNotFoundException : ApplicationException
    {
        public SistemaNotFoundException(string message) : base(message)
        {
        }
    }
}
