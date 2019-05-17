using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.DAL;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        [TestMethod]
        public void GetPrice_WithTaxes_TaxesApplied()
        {
            var initialProductPrice = 5m;
            var taxValue = 1;
            Product product = new Product {Price = initialProductPrice};
            ITax[] taxes = { new TaxDouble(taxValue), new TaxDouble(taxValue), new TaxDouble(taxValue) };

            PriceCalculator target = GetTarget(taxes);


            decimal actualPrice = target.GetPrice(product);

            Assert.AreEqual(8m, actualPrice);
        }


        private PriceCalculator GetTarget(ITax[] taxes)
        {
            ITaxProvider taxesProvider = new TaxProviderDouble(taxes);
            return new PriceCalculator(taxesProvider);
        }
    }

    class TaxDouble : ITax
    {
        private readonly decimal price;

        public TaxDouble(decimal price)
        {
            this.price = price;
        }

        public decimal Calculate(decimal productPrice)
        {
            return price;
        }
    }

    class TaxProviderDouble : ITaxProvider
    {
        private readonly IList<ITax> taxes;

        public TaxProviderDouble(IList<ITax> taxes)
        {
            this.taxes = taxes;
        }

        public IList<ITax> GetTaxes(Product product)
        {
            return taxes;
        }
    }
}