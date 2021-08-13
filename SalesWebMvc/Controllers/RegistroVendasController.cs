using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class RegistroVendasController : Controller
    {
        private readonly RegistroVendasService _RegistroVendasService;
        
        public RegistroVendasController(RegistroVendasService registroVendasService)
        {
            _RegistroVendasService = registroVendasService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? dataInicio, DateTime? dataFim)
        {
            if (!dataInicio.HasValue)
            {
                dataInicio = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!dataFim.HasValue)
            {
                dataFim = DateTime.Now;
            }

            ViewData["DataInicio"] = dataInicio.Value.ToString("yyyy-MM-dd");
            ViewData["DataFim"] = dataFim.Value.ToString("yyyy-MM-dd");

            var resultado = await _RegistroVendasService.EncontrarPorDataAsync(dataInicio, dataFim);
            return View(resultado);
        }

        public async Task<IActionResult> BuscaEmGrupo(DateTime? dataInicio, DateTime? dataFim)
        {
            if (!dataInicio.HasValue)
            {
                dataInicio = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (dataFim.HasValue)
            {
                dataFim = DateTime.Now;
            }

            ViewData["DataInicio"] = dataInicio.Value.ToString("yyyy-MM-dd");
            ViewData["DataFim"] = dataFim.Value.ToString("yyyy-MM-dd");

            var resultado = await _RegistroVendasService.EncontrarPorDataGrupoAsync(dataInicio, dataFim);
            return View(resultado);
        }
    }
}