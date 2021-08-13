using System;

namespace SalesWebMvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Mensagens { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); //Esclamacao testa o metodo para retonar somente id != Null ou vaziu
    }
}