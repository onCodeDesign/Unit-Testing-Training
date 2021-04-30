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

        private TaxesFactory GetTarget()
        {
            return new TaxesFactory();
        }
    }
}