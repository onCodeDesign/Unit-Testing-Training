using System;
using System.Collections.Generic;
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
        public Tax[] Taxes { get; set; }
    }

    public class Tax
    {
        public int  ID { get; set; }
        public string Name { get; set; }
    }

    public static class TaxesValues
    {
        public static readonly Tax Vat = new Tax {ID = 1, Name = "Vat"};
        public static readonly Tax Regional = new Tax {ID = 2, Name = "Regional"};
        public static readonly Tax Luxury = new Tax {ID = 3, Name = "Luxury" };
    }

}
