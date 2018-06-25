using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pos.DataAccess.Model;
using Pos.DataAccess.Repositories;
using Pos.Web.Models;

namespace Pos.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Details(string barcode)
        {
            string code = barcode.Trim().ToLowerInvariant();
            Product p = repository.GetProduct(code);

            ProductViewModel vm = new ProductViewModel
            {
                Code = p.CatalogCode,
                Name = p.CatalogName,
                Price = $"{p.Price} $"
            };

            return View(vm);
        }
    }
}