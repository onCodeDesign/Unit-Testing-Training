using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Pos.Wpf.DAL;

namespace Pos.Wpf
{
    public interface IPriceCalculator
    {
        decimal GetPrice(Product product);
    }

    public class PriceCalculator : IPriceCalculator
    {
        private ITaxProvider taxesProvider;

        public PriceCalculator(ITaxProvider taxesProvider)
        {
            this.taxesProvider = taxesProvider;
        }

        public decimal GetPrice(Product product)
        {
            IEnumerable<ITax> taxes = taxesProvider.GetTaxes(product);
            decimal currentPrice = product.Price;
            foreach (var tax in taxes)
            {
                decimal price = tax.Calculate(product.Price);
                currentPrice = currentPrice + price;
            }

            return currentPrice;
        }
    }

    public interface ITax
    {
        decimal Calculate(decimal productPrice);
    }
}