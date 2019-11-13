using System.Linq;
using Pos.Wpf.DAL;

namespace Pos.Wpf.Services
{
    class PriceCalculator : IPriceCalculator
    {
        public decimal GetPrice(Product product)
        {
            decimal currentPrice = product.Price;

            bool regionalApplied = false;
            if (product.Taxes.Contains(TaxationType.RegionalTax))
            {
                currentPrice = currentPrice + product.Price * 0.1m;
                regionalApplied = true;
            }

            if (product.Taxes.Contains(TaxationType.Vat) && !regionalApplied)
            {
                currentPrice = currentPrice + product.Price * 0.22m;
            }

            if (product.Taxes.Contains(TaxationType.LuxuryTax))
            {
                currentPrice = currentPrice + product.Price * 0.5m;
            }

            return currentPrice;
        }
    }
}