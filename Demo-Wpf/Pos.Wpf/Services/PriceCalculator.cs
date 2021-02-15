using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Pos.Wpf.DAL;
using Pos.Wpf.Services.Taxes;

namespace Pos.Wpf.Services
{
    class PriceCalculator : IPriceCalculator
    {
        private readonly ITaxesFactory taxesFactory;

        public PriceCalculator(ITaxesFactory taxesFactory)
        {
            this.taxesFactory = taxesFactory;
        }

        public decimal GetPrice(Product product)
        {
            IEnumerable<ITax> taxes = taxesFactory.GetTaxesFor(product);

            decimal currentPrice = product.Price;
            foreach (var tax in taxes)
            {
                currentPrice = currentPrice + tax.ApplyFor(product);
            }

            return currentPrice;
        }
    }
}