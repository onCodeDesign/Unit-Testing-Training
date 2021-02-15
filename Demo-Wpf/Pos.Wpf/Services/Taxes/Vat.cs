using Pos.Wpf.DAL;

namespace Pos.Wpf.Services.Taxes
{
    class Vat : ITax
    {
        public decimal ApplyFor(Product product)
        {
            return product.Price * 0.19m;
        }
    }
}