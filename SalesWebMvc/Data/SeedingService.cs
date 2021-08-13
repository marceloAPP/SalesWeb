using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroVendas.Any())
            {
                return; //Banco de Dados já foi populado
            }

            Departamento d1 = new Departamento(1, "Computador");
            Departamento d2 = new Departamento(2, "Eletronicos");
            Departamento d3 = new Departamento(3, "Moda");
            Departamento d4 = new Departamento(4, "Livros");

            Vendedor v1 = new Vendedor(1, "Marcello Santos", "marcello.santos@salesweb.com", new DateTime(2010, 12, 31), 1000.0, d1);
            Vendedor v2 = new Vendedor(2, "Marcelo Souza", "marcelo.souza@salesweb.com", new DateTime(1984, 5, 18), 1000.0, d2);
            Vendedor v3 = new Vendedor(3, "Elaine Santos", "elaine.santos@salesweb.com", new DateTime(1974, 12, 31), 1000.0, d1);
            Vendedor v4 = new Vendedor(4, "Maria Joana", "Maria.joana@salesweb.com", new DateTime(1988, 3, 25), 1000.0, d4);
            Vendedor v5 = new Vendedor(5, "João Marques", "Joao.marques@salesweb.com", new DateTime(1980, 8, 14), 1000.0, d3);
            Vendedor v6 = new Vendedor(6, "Mario Filho", "mario.filho@salesweb.com", new DateTime(1981, 9, 25), 1000.0, d2);

            RegistroVendas rv1 = new RegistroVendas(1, new DateTime(2018, 09, 25), 11000.0, StatusVenda.Faturado, v1);
            RegistroVendas rv2 = new RegistroVendas(2, new DateTime(2018, 09, 4), 7000.0, StatusVenda.Faturado, v5);
            RegistroVendas rv3 = new RegistroVendas(3, new DateTime(2018, 09, 13), 4000.0, StatusVenda.Cancelado, v4);
            RegistroVendas rv4 = new RegistroVendas(4, new DateTime(2018, 09, 1), 8000.0, StatusVenda.Faturado, v1);
            RegistroVendas rv5 = new RegistroVendas(5, new DateTime(2018, 09, 21), 3000.0, StatusVenda.Faturado, v3);
            RegistroVendas rv6 = new RegistroVendas(6, new DateTime(2018, 09, 15), 2000.0, StatusVenda.Faturado, v1);
            RegistroVendas rv7 = new RegistroVendas(7, new DateTime(2018, 09, 28), 13000.0, StatusVenda.Faturado, v2);
            RegistroVendas rv8 = new RegistroVendas(8, new DateTime(2018, 09, 11), 4000.0, StatusVenda.Faturado, v4);
            RegistroVendas rv9 = new RegistroVendas(9, new DateTime(2018, 09, 14), 11000.0, StatusVenda.Pendente, v6);
            RegistroVendas rv10 = new RegistroVendas(10, new DateTime(2018, 09, 7), 9000.0, StatusVenda.Faturado, v6);
            RegistroVendas rv11 = new RegistroVendas(11, new DateTime(2018, 09, 13), 6000.0, StatusVenda.Faturado, v2);
            RegistroVendas rv12 = new RegistroVendas(12, new DateTime(2018, 09, 25), 7000.0, StatusVenda.Pendente, v3);
            RegistroVendas rv13 = new RegistroVendas(13, new DateTime(2018, 09, 29), 10000.0, StatusVenda.Faturado, v4);
            RegistroVendas rv14 = new RegistroVendas(14, new DateTime(2018, 09, 4), 3000.0, StatusVenda.Faturado, v5);
            RegistroVendas rv15 = new RegistroVendas(15, new DateTime(2018, 09, 12), 4000.0, StatusVenda.Faturado, v1);
            RegistroVendas rv16 = new RegistroVendas(16, new DateTime(2018, 10, 5), 2000.0, StatusVenda.Faturado, v4);
            RegistroVendas rv17 = new RegistroVendas(17, new DateTime(2018, 10, 1), 12000.0, StatusVenda.Faturado, v1);
            RegistroVendas rv18 = new RegistroVendas(18, new DateTime(2018, 10, 24), 6000.0, StatusVenda.Faturado, v3);
            RegistroVendas rv19 = new RegistroVendas(19, new DateTime(2018, 10, 22), 8000.0, StatusVenda.Faturado, v5);
            RegistroVendas rv20 = new RegistroVendas(20, new DateTime(2018, 10, 15), 8000.0, StatusVenda.Faturado, v6);
            RegistroVendas rv21 = new RegistroVendas(21, new DateTime(2018, 10, 17), 9000.0, StatusVenda.Faturado, v2);
            RegistroVendas rv22 = new RegistroVendas(22, new DateTime(2018, 10, 24), 4000.0, StatusVenda.Faturado, v4);
            RegistroVendas rv23 = new RegistroVendas(23, new DateTime(2018, 10, 19), 11000.0, StatusVenda.Cancelado, v2);
            RegistroVendas rv24 = new RegistroVendas(24, new DateTime(2018, 10, 12), 8000.0, StatusVenda.Faturado, v5);
            RegistroVendas rv25 = new RegistroVendas(25, new DateTime(2018, 10, 31), 7000.0, StatusVenda.Faturado, v3);
            RegistroVendas rv26 = new RegistroVendas(26, new DateTime(2018, 10, 6), 5000.0, StatusVenda.Faturado, v4);
            RegistroVendas rv27 = new RegistroVendas(27, new DateTime(2018, 10, 13), 9000.0, StatusVenda.Faturado, v1);
            RegistroVendas rv28 = new RegistroVendas(28, new DateTime(2018, 10, 7), 4000.0, StatusVenda.Faturado, v3);
            RegistroVendas rv29 = new RegistroVendas(29, new DateTime(2018, 10, 23), 12000.0, StatusVenda.Faturado, v5);
            RegistroVendas rv30 = new RegistroVendas(30, new DateTime(2018, 10, 12), 5000.0, StatusVenda.Faturado, v2);

            _context.Departamento.AddRange(d1, d2, d3, d4);

            _context.Vendedor.AddRange(v1, v2, v3, v4, v5, v6);

            _context.RegistroVendas.AddRange(
                rv1, rv2, rv3, rv4, rv5, rv6, rv7, rv8, rv9, rv10, rv11,
                rv12, rv13, rv14, rv15, rv16, rv17, rv18, rv19, rv20, rv21,
                rv22, rv23, rv24, rv25, rv26, rv27, rv28, rv29, rv30
            );

            _context.SaveChanges();

        }
    }
}

