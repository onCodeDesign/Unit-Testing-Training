using Microsoft.AspNetCore.Mvc;
using Pos.DataAccess.Model;
using Pos.Web.Models;

namespace Pos.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        private readonly IPriceCalculator priceCalculator;

        public ProductController(IProductRepository repository, IPriceCalculator priceCalculator)
        {
            this.repository = repository;
            this.priceCalculator = priceCalculator;
        }

        public IActionResult Details(string barcode)
        {
            Product p = repository.GetProductByBarcode(barcode);

            ProductViewModel vm;
            if (p != null)
            {
                decimal price = priceCalculator.GetPrice(p);
                vm = new ProductViewModel
                {
                    Code = p.CatalogCode,
                    Name = p.CatalogName,
                    Price = $"{price} $",
                };
            }
            else
                vm = new ProductViewModel {Name = "Not Available"};

            return View(vm);
        }
    }
}