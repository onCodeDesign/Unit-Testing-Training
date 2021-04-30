using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.xUnitEx;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.DAL;
using Pos.Wpf.Services.Taxes;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class TaxesFactoryTests
    {
        [TestMethod]
        public void GetTaxesFor_ProductWithVatOnly_OnlyVatTaxReturned() => RunTest__GetTaxes(
            new[] { TaxationType.Vat },
            new[] { typeof(Vat)});
        

        [TestMethod]
        public void GetTaxesFor_ProductWithVatAndRegionalTax_OnlyRegionalTaxReturned() => RunTest__GetTaxes(
            new[] {TaxationType.Vat, TaxationType.RegionalTax},
            new[] {typeof(RegionalTax)});

        [TestMethod]
        public void GetTaxes_ForProductWithNoTaxes_NoTaxesReturned() => RunTest__GetTaxes(
            new TaxationType[] { },
            new Type[] { });

        [TestMethod]
        public void GetTaxes_ForProductWithAllTaxes_RegionalAndLuxuryReturned() => RunTest__GetTaxes(
            new[] {TaxationType.Vat, TaxationType.RegionalTax, TaxationType.LuxuryTax},
            new[] {typeof(RegionalTax), typeof(LuxuryTax)});

        [TestMethod]
        public void GetTaxes_ForProductWithRegionalAndLuxury_RegionalAndLuxuryReturned() => RunTest__GetTaxes(
            new[] {TaxationType.RegionalTax, TaxationType.LuxuryTax},
            new[] {typeof(RegionalTax), typeof(LuxuryTax)});

        private void RunTest__GetTaxes(TaxationType[] taxes, Type[] expectedTaxTypes)
        {
            var target = GetTarget();
            Product product = new Product { Taxes = taxes };

            var actualTaxes = target.GetTaxesFor(product);

            IEnumerable<Type> actualTaxesTypes = actualTaxes.Select(x => x.GetType());
            AssertEx.AreEquivalent(actualTaxesTypes, expectedTaxTypes);
        }

        private TaxesFactory GetTarget()
        {
            return new TaxesFactory();
        }
    }
}