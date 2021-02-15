using System.Linq;
using Pos.Wpf.DAL;

namespace Pos.Wpf.Services.Taxes
{
    class LuxuryTax : ITax
    {
        private readonly ITax regionalTax;

        public LuxuryTax()
            :this(new RegionalTax())
        {
        }

        public LuxuryTax(ITax regionalTax)
        {
            this.regionalTax = regionalTax;
        }

        public decimal ApplyFor(Product product)
        {
            if (product.Price < 100)
                return product.Price * 0.15m;

            if (product.Price < 70000)
            {
                if (product.Category == GoodsCategory.Specialty)
                    return product.Price * 2;

                return product.Price * 0.75m;
            }

            if (product.Category == GoodsCategory.Specialty)
            {
                decimal basePrice = product.Price;
                if (product.Taxes.Contains(TaxationType.RegionalTax))
                    basePrice = regionalTax.ApplyFor(product);

                return  basePrice * 1.8m;
            }

            if (product.Category == GoodsCategory.Shopping)
            {
                return product.Price * 1.8m;
            }
         
            return product.Price * 1.5m;
        }
    }
}