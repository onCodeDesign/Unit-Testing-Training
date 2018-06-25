using Microsoft.EntityFrameworkCore;
using Pos.DataAccess.Model;

namespace Pos.DataAccess.DbContext
{
    class MyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Product> Products { get; set; } 
    }
}