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
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments};

            return View(viewModel);
        }
        public IActionResult Delete(int ? id)
        {
            if(id is null)  return RedirectToAction(nameof(Error), new {message = "Id not provided"});

            var obj = _sellerService.FindById(id.Value);
            if (obj is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id is null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerService.FindById(id.Value);
            if (obj is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id is null) return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerService.FindById(id.Value);
            if (obj is null) return RedirectToAction(nameof(Error), new { message = "Id not found" });

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _sellerService.Update(seller);
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
