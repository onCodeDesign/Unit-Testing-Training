using Pos.DataAccess.Model;

namespace Pos.DataAccess.Repositories
{
    public interface IProductRepository
    {
        Product GetProduct(string code);
    }
}