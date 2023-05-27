using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pos.Web.Models;

namespace Pos.Web.Controllers
{
    public class ProductController : Controller
    {
        // Product/Details
        public IActionResult Details(string barcode)
        {
            ProductViewModel vm = new ProductViewModel();

            return View(vm);
        }
    }
}