using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Wpf.DAL
{
    public class Product
    {
        public string Barcode { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public decimal Price { get; set; }
        public bool HasVat { get; set; }
    }
}
