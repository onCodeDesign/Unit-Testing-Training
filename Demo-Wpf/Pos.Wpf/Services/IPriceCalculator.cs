using System;
using Pos.Wpf.DAL;

namespace Pos.Wpf.Services
{
    public interface IPriceCalculator
    {
        decimal GetPrice(Product product);
    }

    class PriceCalculator : IPriceCalculator
    {
        public decimal GetPrice(Product product)
        {
            throw new NotImplementedException();
        }
    }
}