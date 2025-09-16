using Microsoft.AspNetCore.Mvc;
using SalesWebCourse.Services;
using SalesWebCourse.Models;
using SalesWebCourse.Models.ViewModels;
using SalesWebCourse.Services.Exceptions;
using System.Diagnostics;

namespace SalesWebCourse.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }
        public async Task<IActionResult> Create()
        {
            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Departments = departments};

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Seller seller)
        {
            // Log para depuração (opcional)
            Console.WriteLine($"DepartmentId recebido: {seller.DepartmentId}");

            if (!ModelState.IsValid)
            {
                // Remove a validação para a propriedade de navegação (Department), pois só precisamos do ID
                ModelState.Remove("Seller.Department");

                // Verifica novamente se ainda há erros (agora deve ser válido)
                if (!ModelState.IsValid)
                {
                    var departments = await _departmentService.FindAllAsync();
                    var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                    return View(viewModel);
                }
            }

            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int ? id)
        {
            if(id is null)  return RedirectToAction(nameof(Error), new {message = "Id not provided"});

            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Delete(int id)
        {
            await _sellerService.RemoveAsync(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(obj);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) 
            { 
                return RedirectToAction(nameof(Error), new { message = "Id not provided" }); 
            }
            var obj =  await _sellerService.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            var departments = await _departmentService.FindAllAsync();
            var viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Seller seller)
        {
            Console.WriteLine($"DepartmentId recebido: {seller.DepartmentId}");
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            if (!ModelState.IsValid)
            {
                ModelState.Remove("Seller.Department");

                if (!ModelState.IsValid)
                {
                    var departments = await _departmentService.FindAllAsync();
                    var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                    return View(viewModel);
                }
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);
                return RedirectToAction("Index");
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
        public IActionResult Error(string message)
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
