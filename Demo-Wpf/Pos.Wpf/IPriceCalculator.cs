using Pos.Wpf.DAL;

namespace Pos.Wpf
{
    public interface IPriceCalculator
    {
        decimal GetPrice(Product product);
    }
}