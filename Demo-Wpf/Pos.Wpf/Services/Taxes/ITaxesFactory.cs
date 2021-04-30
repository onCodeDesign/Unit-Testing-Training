using System;
using System.Collections.Generic;
using System.Linq;
using Pos.Wpf.DAL;

namespace Pos.Wpf.Services.Taxes
{
    interface ITaxesFactory
    {
        IEnumerable<ITax> GetTaxesFor(Product product);
    }

    class TaxesFactory : ITaxesFactory
    {
        public IEnumerable<ITax> GetTaxesFor(Product product)
        {
            HashSet<TaxationType> taxationTypes = product.Taxes.ToHashSet();

            foreach (var taxationType in taxationTypes)
            {
                switch (taxationType)
                {
                    case TaxationType.Vat:
                        if (!taxationTypes.Contains(TaxationType.RegionalTax))
                            yield return new Vat();
                        break;

                    case TaxationType.RegionalTax:
                        yield return new RegionalTax();
                        break;

                    case TaxationType.LuxuryTax:
                        yield return new LuxuryTax();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}