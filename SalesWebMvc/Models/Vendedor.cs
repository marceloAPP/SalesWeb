using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")] // Define que o campo é obrigadtorio
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Tamanho do {0} entre {2} e {1} caracteres")] //Define a quantidade maxima, e minino de string
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com um E-mail válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data de Nascimento")] //Formatar o nome da variavel que vai aparecer em telas e formularios 
        [DataType(DataType.Date)] //Formatar como tipo do dado será apresentada em telas e formularios
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //Formatar como a data será apresentada
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")] //Formatar a casa decimal de como será apresentado o numeros
        public double Salario { get; set; }
        
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

        public Vendedor() { }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Salario = salario;
            Departamento = departamento;
        }

        public void AdicionarVenda(RegistroVendas registrarVenda)
        {
            Vendas.Add(registrarVenda);
        }

        public void RemoverVenda(RegistroVendas removerVenda)
        {
            Vendas.Remove(removerVenda);
        }

        public double TotalVendas(DateTime dataInicio, DateTime dataFim)
        {
            return Vendas.Where(registroVenda => registroVenda.Data >= dataInicio && registroVenda.Data <= dataFim).Sum(registroVenda => registroVenda.Valor);
        }

    }
}
