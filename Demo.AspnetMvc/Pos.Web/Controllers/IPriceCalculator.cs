using Pos.DataAccess.Model;

namespace Pos.Web.Controllers
{
    public interface IPriceCalculator
    {
        decimal GetPrice(Product product);
    }
}