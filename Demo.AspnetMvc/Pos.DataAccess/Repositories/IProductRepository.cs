using Pos.DataAccess.Model;

namespace Pos.Web.Controllers
{
    public interface IProductRepository
    {
        Product GetProductByBarcode(string barcode);
    }
}