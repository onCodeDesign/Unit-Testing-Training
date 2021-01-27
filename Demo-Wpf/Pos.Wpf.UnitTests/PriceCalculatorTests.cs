using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        [TestMethod]
        public void GetPrice_ProductWithVatOnly_VatApplied()
        {
            PriceCalculator target = GetTarget();
            Product product = new Product {Price = 10m, Taxes = new[] {TaxationType.Vat}};

            decimal actualPrice = target.GetPrice(product);

            Assert.AreEqual(11.9m, actualPrice);
        }

        [TestMethod]
        public void GetPrice_ProductWithVatAndRegionalTax_OnlyRegionalTaxApplied()
        {
            PriceCalculator target = GetTarget();
            Product product = new Product { Price = 10m, Taxes = new[] { TaxationType.Vat, TaxationType.RegionalTax } };

            decimal actualPrice = target.GetPrice(product);

            Assert.AreEqual(11m, actualPrice);
        }

        [TestMethod]
        public void GetPrice_ProductWithNoTaxes_PriceCatalogApplied()
        {
            PriceCalculator target = GetTarget();
            Product product = new Product { Price = 10m, Taxes = new TaxationType[0]  };

            decimal actualPrice = target.GetPrice(product);

            Assert.AreEqual(10m, actualPrice);
        }

        private PriceCalculator GetTarget()
        {
            return new PriceCalculator();
        }
    }
}