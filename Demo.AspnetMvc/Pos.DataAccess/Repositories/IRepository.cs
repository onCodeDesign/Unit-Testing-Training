using System.Linq;

namespace Pos.DataAccess.Repositories
{
    public interface IRepository
    {
        IQueryable<T> GetEntity<T>();
    }
}