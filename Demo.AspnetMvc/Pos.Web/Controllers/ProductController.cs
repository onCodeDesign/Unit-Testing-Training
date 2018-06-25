using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pos.DataAccess.Model;

namespace Pos.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details(string barcode)
        {

            return View();
        }
    }
}