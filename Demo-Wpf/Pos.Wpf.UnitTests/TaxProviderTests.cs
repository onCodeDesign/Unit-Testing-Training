using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.DAL;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class TaxProviderTests
    {
        [TestMethod]
        public void GetTaxes_ProductWithRegionalTax_RegionalTaxAdded()
        {
            Test__GetTaxes_ProductWithATax_TaxAdded(TaxingType.RegionalTax,typeof(RegionalTax));
        }

        [TestMethod]
        public void GetTaxes_ProductWithLuxuryTax_LuxuryTaxAdded()
        {
            Test__GetTaxes_ProductWithATax_TaxAdded(TaxingType.LuxuryTax, typeof(LuxuryTax));
        }

        private void Test__GetTaxes_ProductWithATax_TaxAdded(TaxingType tax, Type taxType)
        {
            TaxProvider target = GetTarget();
            Product product = new Product { Taxes = tax };

            IEnumerable<ITax> actualTaxes = target.GetTaxes(product);

            Assert.IsTrue(actualTaxes.Any(taxType.IsInstanceOfType), $"{taxType.Name} expected, but not found");
        }

        private TaxProvider GetTarget()
        {
            return new TaxProvider();
        }
    }
}