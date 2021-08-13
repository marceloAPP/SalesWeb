using System;

namespace SalesWebMvc.Services.Exceptions
{
    public class SistemaIntegrityException : ApplicationException
    {
        public SistemaIntegrityException(string mensagem) : base(mensagem)
        {

        }
    }
}
