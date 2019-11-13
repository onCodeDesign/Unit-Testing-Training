using Pos.Wpf.DAL;

namespace Pos.Wpf.Services
{
    public interface IPriceCalculator
    {
        decimal GetPrice(Product product);
    }
}