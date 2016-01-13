using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class FakeController : Controller
    {
        public ActionResult Index()
        {
            return View(FakeDb.GetCategories());
        }

        public ActionResult Products(int pid)
        {
            IEnumerable<Product> products = FakeDb.GetProductsByCategoryId(pid);
            Category c = FakeDb.GetCategoryById(pid);
            ProductsViewModel viewModel = new ProductsViewModel();
            viewModel.Products = products;
            viewModel.Category = c;
            return View(viewModel);
        }

    }
}
