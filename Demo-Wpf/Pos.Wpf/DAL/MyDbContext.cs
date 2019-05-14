using System.Data.Entity;

namespace Pos.Wpf.DAL
{
    class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("connectionString")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}