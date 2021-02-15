using System.Data.Entity;
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
                currentPrice = currentPrice + product.Price * 0.19m;
            }

            if (product.Taxes.Contains(TaxationType.LuxuryTax))
            {
                if (currentPrice < 100)
                {
                    currentPrice += product.Price * 0.15m;
                }
                else if (currentPrice < 70000)
                {
                    if (product.Category == GoodsCategory.Specialty)
                    {
                        currentPrice *= 2;
                    }
                    else
                    {
                        currentPrice = currentPrice + product.Price * 0.75m;
                    }
                }
                else
                {
                    if (product.Category == GoodsCategory.Specialty)
                    {
                        currentPrice = currentPrice + currentPrice * 1.8m;
                    }
                    else if (product.Category == GoodsCategory.Shopping)
                    {
                        currentPrice = currentPrice + product.Price * 1.8m;
                    }
                    else
                    {
                        currentPrice = currentPrice + product.Price * 1.5m;
                    }
                }
            }

            return currentPrice;
        }
    }

    
}