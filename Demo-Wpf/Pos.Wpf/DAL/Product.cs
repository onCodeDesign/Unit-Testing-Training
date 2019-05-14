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
        public TaxingType Taxes { get; set; }
    }

    [Flags]
    public enum TaxingType
    {
        None = 0,
        Vat = 1,
        RegionalTax = 2,
        Discount = 4
    }

}
