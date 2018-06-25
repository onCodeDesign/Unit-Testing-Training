using Microsoft.AspNetCore.Mvc;
using Pos.DataAccess.Model;
using Pos.Web.Models;

namespace Pos.Web.Controllers
{
    public class ProductController2 : Controller
    {
        public IActionResult Details(string barcode)
        {
            Product product;
            using (var db = new MyContext())
            {
                product = db.Products.FirstOrDefault(p => p.Barcode == e.Barcode);
            }

            ProductViewModel vm = new ProductViewModel();
            if (product != null)
            {
                decimal currentPrice = product.Price;

                bool regionalApplied = false;
                if (product.Taxes.HasFlag(TaxingType.RegionalTax))
                {
                    currentPrice = currentPrice + product.Price * 0.1m;
                    regionalApplied = true;
                }

                if (product.Taxes.HasFlag(TaxingType.Tva) && !regionalApplied)
                {
                    currentPrice = currentPrice + product.Price * 0.22m;
                }

                if (product.Taxes.HasFlag(TaxingType.LuxuryTax))
                {
                    currentPrice = currentPrice + product.Price * 0.5m;
                }

                if (product.Taxes.HasFlag(TaxingType.Discount))
                {
                    currentPrice = currentPrice - currentPrice * 0.3m;
                }
            }

            return View(vm);
        }
    }
}