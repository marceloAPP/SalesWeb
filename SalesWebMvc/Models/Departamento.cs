using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento() { }

        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AdicionarVendedor(Vendedor vendedores)
        {
            Vendedores.Add(vendedores);
        }

        public double TotalVendas(DateTime dataInicio, DateTime dataFim)
        {
            return Vendedores.Sum(v => v.TotalVendas(dataInicio, dataFim));
        }


    }
}
