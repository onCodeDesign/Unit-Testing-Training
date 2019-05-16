using System;
using System.Linq;
using Pos.Wpf.DAL;

namespace Pos.Wpf
{
    public interface IRepository
    {
        Product GetProduct(string productBarcode);
    }

    class Repository : IRepository
    {
        public Product GetProduct(string productBarcode)
        {
            using (var db = new MyDbContext() )
            {
                return db.Products.FirstOrDefault(p => p.Barcode == productBarcode);
            }
        }
    }
}