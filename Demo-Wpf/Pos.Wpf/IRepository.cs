using System.Linq;

namespace Pos.Wpf
{
    public interface IRepository
    {
        IQueryable<T> GetEntities<T>();
    }
}