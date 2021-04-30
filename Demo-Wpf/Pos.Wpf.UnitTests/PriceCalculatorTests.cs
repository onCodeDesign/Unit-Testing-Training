using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;
using Pos.Wpf.Services.Taxes;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class PriceCalculatorTests
    {
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
            Mock<ITaxesFactory> taxesFactory = new Mock<ITaxesFactory>();
            taxesFactory.Setup(tf => tf.GetTaxesFor(It.IsAny<Product>())).Returns(Enumerable.Empty<ITax>());
            
            return new PriceCalculator(taxesFactory.Object);
        }
    }
}