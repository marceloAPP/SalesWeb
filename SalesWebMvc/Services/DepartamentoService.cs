using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMvcContext _context;

        public DepartamentoService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Metodo asincrono mantem o sistema funcionando emquanto operacoes de banco de dados, rede e HD
        //são executados. Utilizar somente para pequenas consultas.      
        public async Task<List<Departamento>> BuscarTodosAsync() //incluir a palavra "async" e Task<>. Async no nome do metodo é opcional.
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync(); //Incluir a palavra await
        }
    }
}
