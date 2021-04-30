using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pos.Wpf.DAL;
using Pos.Wpf.Services.Taxes;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class LuxuryTaxTests
    {
        [TestMethod]
        public void ApplyFor_SpecialtyOver70Priced_180PercentageApplied()
        {
            Product product = new Product {Price = 71000, Category = GoodsCategory.Specialty};
            LuxuryTax target = GetTarget();

            decimal actual = target.ApplyFor(product);

            Assert.AreEqual(71000*1.8m, actual);
        }

        [TestMethod]
        public void ApplyFor_SpecialtyOver70PricedWithRegionalTax_180PercentageAppliedOnTopOfRegional()
        {
            Product product = new Product {Price = 71000, Category = GoodsCategory.Specialty, Taxes = new[] {TaxationType.RegionalTax}};
            Mock<ITax> regionalTaxStub = new Mock<ITax>();
            regionalTaxStub.Setup(r => r.ApplyFor(It.IsAny<Product>())).Returns(10);

            LuxuryTax target = GetTarget(regionalTaxStub.Object);

            decimal actual = target.ApplyFor(product);

            Assert.AreEqual(18m, actual);
        }

        private LuxuryTax GetTarget(ITax tax)
        {
            return new LuxuryTax(tax);
        }

        private LuxuryTax GetTarget()
        {
            Mock<ITax> regionalTaxStub = new Mock<ITax>();
            regionalTaxStub.Setup(r => r.ApplyFor(It.IsAny<Product>())).Returns<Product>(p => p.Price);
            return GetTarget(regionalTaxStub.Object);
        }
    }
}