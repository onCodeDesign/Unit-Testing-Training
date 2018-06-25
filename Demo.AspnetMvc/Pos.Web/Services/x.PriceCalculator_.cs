using Pos.DataAccess.Model;

namespace Pos.Web.Services
{
    public class PriceCalculator2 : IPriceCalulator
    {
        public decimal GetPrice(Product product)
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

            if (currentPrice < 0)
                return 0;

            return currentPrice;
        }
    }
}