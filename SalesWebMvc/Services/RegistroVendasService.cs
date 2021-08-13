using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class RegistroVendasService
    {
        private readonly SalesWebMvcContext _context;

        public RegistroVendasService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroVendas>> EncontrarPorDataAsync(DateTime? dataInicio, DateTime? dataFim)
        {
            var resultado = from obj in _context.RegistroVendas select obj;

            if (dataInicio.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataInicio.Value);
            }

            if (dataFim.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataFim.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, RegistroVendas>>> EncontrarPorDataGrupoAsync(DateTime? dataInicio, DateTime? dataFim)
        {
            var resultado = from obj in _context.RegistroVendas select obj;

            if (dataInicio.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= dataInicio.Value);
            }

            if (dataFim.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= dataFim.Value);
            }

            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }
    }
}
