using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Wpf.DAL
{
    public class Product : IEquatable<Product>
    {
        public string Barcode { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public decimal Price { get; set; }
        public Tax[] Taxes { get; set; }

        public bool Equals(Product other)
        {
            return this.CatalogName == other.CatalogName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(Product left, Product right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Product left, Product right)
        {
            return !Equals(left, right);
        }
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
