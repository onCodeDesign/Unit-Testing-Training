using System.Collections.Generic;
using Pos.Wpf.DAL;

namespace Pos.Wpf
{
    public interface ITaxProvider
    {
        IList<ITax> GetTaxes(Product product);
    }

    public class TaxProvider : ITaxProvider
    {
        public IList<ITax> GetTaxes(Product product)
        {
            List<ITax> taxes = new List<ITax>();

            if (product.Taxes.HasFlag(TaxingType.RegionalTax))
                taxes.Add(new RegionalTax());

            if (product.Taxes.HasFlag(TaxingType.LuxuryTax))
                taxes.Add(new LuxuryTax());

            if (product.Taxes.HasFlag(TaxingType.Vat) && !product.Taxes.HasFlag(TaxingType.RegionalTax))
                taxes.Add(new VatTax());

            if (product.Taxes.HasFlag(TaxingType.Discount))
                taxes.Add(new Discount());

            return taxes;
        }

        
    }

    internal class Discount : ITax
    {
        public decimal Calculate(decimal productPrice)
        {
            throw new System.NotImplementedException();
        }
    }

    internal class VatTax : ITax
    {
        public decimal Calculate(decimal productPrice)
        {
            return productPrice * 0.19m;
        }
    }

    public class LuxuryTax : ITax
    {
        public decimal Calculate(decimal productPrice)
        {
            throw new System.NotImplementedException();
        }
    }

    public class RegionalTax : ITax
    {
        public decimal Calculate(decimal productPrice)
        {
            throw new System.NotImplementedException();
        }
    }
}