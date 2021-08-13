using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Services.Exceptions;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedoresService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedoresService vendedorServices, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorServices;
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _vendedorService.EncontrarTodosAsync();
            return View(list);
        }

        public async Task<IActionResult> Criar()
        {
            var departamentos = await _departamentoService.BuscarTodosAsync();
            var viewModel = new VendedoresFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Evitar ataques utilizando a autenticacao da Pagina.
        public async Task<IActionResult> Criar(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoService.BuscarTodosAsync();
                var viewModel = new VendedoresFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorService.InserirAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Excluir(int? id) //interrogacao para indicar que o paramentro é opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Código Vendedor não  foi fornecido!" });
            }

            var obj = await _vendedorService.EncontarIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Vendedor não encontrado!" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] ////Evitar ataques utilizando a autenticacao da Pagina.
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                await _vendedorService.RemoverAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (SistemaIntegrityException e)
            {

                return RedirectToAction(nameof(Error), new {mensagem = e.Message});
            }            
        }

        public async Task<IActionResult> Detalhes(int? id) //interrogacao para indicar que o paramentro é opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Código Vendedor não  foi fornecido!" });
            }

            var obj = await _vendedorService.EncontarIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Vendedor não encontrado!" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id) //interrogacao para indicar que o paramentro é opcional
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Código Vendedor não foi fornecido!" });
            }

            var obj = await _vendedorService.EncontarIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Vendor não encontrado!" });
            }

            List<Departamento> listaDepartamentos = await _departamentoService.BuscarTodosAsync();
            VendedoresFormViewModel viewModelVendedor = new VendedoresFormViewModel { Vendedor = obj, Departamentos = listaDepartamentos };

            return View(viewModelVendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    var departamentos = await _departamentoService.BuscarTodosAsync();
                    var viewModel = new VendedoresFormViewModel { Vendedor = vendedor, Departamentos = departamentos };
                    return View(viewModel);
                }
                
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { mensagem = "Id do vendedor imcompativél." });
            }

            try
            {
                await _vendedorService.AlteracaoAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (SistemaNotFoundException e)
            {

                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }
            catch (SistemaDbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { mensagem = e.Message });
            }

        }

        public IActionResult Error(string mensagem)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagens = mensagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //Uma integragação indica opcional. Duas integragação indica juncao de nulo ou alguma coisa, nesse caso o HttpContext
            };

            return View(viewModel);
        }
    }
}