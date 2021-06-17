using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Models.ViewModels;
using VendasWeb.Services;
using AutoMapper;
using VendasWeb.Services.Exceptions;
using System.Diagnostics;

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

        public async Task<IActionResult> Index()
        {
            var list = await _vendedorService.FindAllAsync();

            return View(list);
        }

        public async Task<IActionResult> Criar()
        {
            var departamentos = await _departamentosService.FindAllAsync();
            var viewModel = new VendedorFormViewModel { Departamentoss = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(VendedorFormViewModel vendedoresViewModel)
        {
            if(!ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                {
                    var departamentos = await _departamentosService.FindAllAsync();
                    var viewModel = new VendedorFormViewModel { Nome = vendedoresViewModel.Nome, Email = vendedoresViewModel.Email, Aniversario = vendedoresViewModel.Aniversario, SalarioBase = vendedoresViewModel.SalarioBase, Departamentos = vendedoresViewModel.Departamentos, DepartamentosId = vendedoresViewModel.DepartamentosId, Departamentoss = departamentos };

                    return View(viewModel);
                }
            }


            var vendedores = _iMapper.Map<Vendedor>(vendedoresViewModel);

            await _vendedorService.InserirAsync(vendedores);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id não foi fornecido" });
            }

            var obj = await _vendedorService.ProcurarPeloIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id não encontrado" });
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _vendedorService.RemoverAsync(id);
                return RedirectToAction(nameof(Index));
            }

            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Erro), new { message = e.Message});
            }
        }


        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id não foi fornecido" });
            }

            var obj = await _vendedorService.ProcurarPeloIdAsync(id.Value);
            if (obj == null)
            {
                RedirectToAction(nameof(Erro), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Editar(int? id)
        {

            if (id == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id não foi fornecido" });
            }

            var obj = await _vendedorService.ProcurarPeloIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id não encontrado" }); ;
            }

            List<Departamentos> departamentos = await _departamentosService.FindAllAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Id = obj.Id, Nome = obj.Nome, Email = obj.Email, Aniversario = obj.Aniversario, SalarioBase = obj.SalarioBase, Departamentos = obj.Departamentos, DepartamentosId = obj.DepartamentosId, Departamentoss = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {

            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentosService.FindAllAsync();
                var viewModel = new VendedorFormViewModel { Nome = vendedor.Nome, Email = vendedor.Email, Aniversario = vendedor.Aniversario, SalarioBase = vendedor.SalarioBase, Departamentos = vendedor.Departamentos, DepartamentosId = vendedor.DepartamentosId, Departamentoss = departamentos };

                return View(viewModel);
            }


            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Erro), new { message = "Id não corresponde" });
            }
            try
            {
                await _vendedorService.AtualizarAsync(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Erro), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Erro), new { message = e.Message });
            }
        }

        public IActionResult Erro(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);

        }


    }
}
