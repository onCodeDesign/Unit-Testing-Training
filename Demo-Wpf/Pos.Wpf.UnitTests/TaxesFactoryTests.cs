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
        public void GetTaxesFor_ProductWithVatOnly_OnlyVatTaxReturned()
        {
            TaxesFactory target = GetTarget();
            Product product = new Product { Taxes = new[] { TaxationType.Vat } };

            var actualTaxes = target.GetTaxesFor(product);

            var actualTaxesTypes = actualTaxes.Select(x => x.GetType());
            AssertEx.AreEquivalent(actualTaxesTypes, typeof(Vat));
        }

        [TestMethod]
        public void GetTaxesFor_ProductWithVatAndRegionalTax_OnlyRegionalTaxReturned()
        {
            TaxesFactory target = GetTarget();
            Product product = new Product { Taxes = new[] { TaxationType.Vat, TaxationType.RegionalTax } };

            var actualTaxes = target.GetTaxesFor(product);

            var actualTaxesTypes = actualTaxes.Select(x => x.GetType());
            AssertEx.AreEquivalent(actualTaxesTypes, typeof(RegionalTax));

        }

        [TestMethod]
        public void GetTaxes_ForProductWithNoTaxes_NoTaxesReturned()
        {
            TaxesFactory target = GetTarget();
            Product product = new Product();

            var actualTaxes = target.GetTaxesFor(product);

            Assert.AreEqual(0, actualTaxes.Count());
        }

        [TestMethod]
        public void GetTaxes_ForProductWithAllTaxes_RegionalAndLuxuryReturned()
        {
            var target = GetTarget();
            Product product = new Product{Taxes = new [] {TaxationType.Vat, TaxationType.RegionalTax, TaxationType.LuxuryTax}};

            var actualTaxes = target.GetTaxesFor(product);

            IEnumerable<Type> actualTaxesTypes = actualTaxes.Select(x => x.GetType());
            AssertEx.AreEquivalent(actualTaxesTypes, typeof(RegionalTax), typeof(LuxuryTax));
        }

        private TaxesFactory GetTarget()
        {
            return new TaxesFactory();
        }
    }
}