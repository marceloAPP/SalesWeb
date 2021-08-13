using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class VendedoresService
    {
        private readonly SalesWebMvcContext _context;

        public VendedoresService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //Metodo asincrono mantem o sistema funcionando emquanto operacoes de banco de dados, rede e HD
        //são executados. Utilizar somente para pequenas consultas.
        public async Task<List<Vendedor>> EncontrarTodosAsync() //incluir a palavra "async" e Task<>. Async no nome do metodo é opcional.
        {
            return await _context.Vendedor.ToListAsync(); //Incluir a palavra await
        }

        public async Task InserirAsync(Vendedor obj)// Para asincrono quando for void utilizar "Task" no lugar do void
        {
            _context.Add(obj);
            await _context.SaveChangesAsync(); //Inclui await no começo do retorno

        }

        public async Task<Vendedor> EncontarIdAsync(int id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoverAsync(int id) // Para asincrono quando for void utilizar "Task" no lugar do void
        {
            try
            {
                var obj = await _context.Vendedor.FindAsync(id);
                _context.Vendedor.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {

                throw new SistemaIntegrityException("Exclusão não permitida, existe venda atribuida a esse vendedor!");
            }

            
        }

        public async Task AlteracaoAsync(Vendedor ObjVendedor)
        {
            bool existe = await _context.Vendedor.AnyAsync(x => x.Id == ObjVendedor.Id);
            if (!existe)
            {
                throw new SistemaNotFoundException("ID não encontrado");
            }

            try
            {
                _context.Update(ObjVendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {

                throw new SistemaDbConcurrencyException(e.Message);
            }
            
        }
    }
}
