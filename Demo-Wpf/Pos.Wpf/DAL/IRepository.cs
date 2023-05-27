using System.Data.Entity;
using System.Linq;

namespace Pos.Wpf.DAL
{
    public interface IRepository
    {
        IQueryable<T> GetEntities<T>() where T : class;
    }

    class Repository : IRepository
    {
        private readonly DbContext dbContext = new MyDbContext();

        public IQueryable<T> GetEntities<T>() where T : class
        {
            return dbContext.Set<T>().AsNoTracking();
        }
    }
}