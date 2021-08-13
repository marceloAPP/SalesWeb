using System;
using System.ComponentModel.DataAnnotations;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Models
{
    public class RegistroVendas
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Valor { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroVendas() { }

        public RegistroVendas(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {   
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }

    
}
