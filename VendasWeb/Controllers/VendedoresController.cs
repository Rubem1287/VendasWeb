using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Models.ViewModels;
using VendasWeb.Services;
using AutoMapper;

namespace VendasWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly IMapper _iMapper;
        private readonly VendedorService _vendedorService;
        private readonly DepartamentosService _departamentosService;

        public VendedoresController(IMapper iMapper, VendedorService vendedorService, DepartamentosService departamentosService)
        {
            _iMapper = iMapper;
            _vendedorService = vendedorService;
            _departamentosService = departamentosService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.FindAll();

            return View(list);
        }

        public IActionResult Criar()
        {
            var departamentos = _departamentosService.FindAll();
            var viewModel = new VendedorFormViewModel { Departamentoss = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(VendedorFormViewModel vendedoresViewModel)
        {
            var vendedores = _iMapper.Map<Vendedor>(vendedoresViewModel);

            _vendedorService.Inserir(vendedores);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var obj = _vendedorService.ProcurarPeloId(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedorService.Remover(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
