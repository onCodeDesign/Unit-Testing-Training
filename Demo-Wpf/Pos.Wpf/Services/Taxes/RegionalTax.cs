using Pos.Wpf.DAL;

namespace Pos.Wpf.Services.Taxes
{
    class RegionalTax : ITax
    {
        public decimal ApplyFor(Product product)
        {
            return product.Price * 0.1m;
        }
    }
}