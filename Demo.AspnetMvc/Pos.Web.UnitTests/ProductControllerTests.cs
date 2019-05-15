using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.DataAccess.Model;
using Pos.DataAccess.Repositories;
using Pos.Web.Controllers;
using Pos.Web.Models;

namespace Pos.Web.UnitTests
{
    [TestClass]
    public class ProductControllerTests 
    {
        [TestMethod]
        public void Details_ProductExists_ProductCodeIsDisplayed()
        {
            string barcode = "some product barcode";
            Product productTestData = new Product {CatalogCode = "some code"};

            IProductRepository repository = new ProductRepositoryDouble(productTestData);
            ProductController target = new ProductController(repository);


            var actionResult = target.Details(barcode);

            ProductViewModel vm = actionResult.GetViewModel<ProductViewModel>();
            Assert.AreEqual("some code", vm.Code);
        }

        [TestMethod]
        public void Details_ProductExists_PriceHasCurrencySymbol()
        {
            Assert.Fail("Not yet implemented");
        }

        [TestMethod]
        public void Details_BarcodeWithUppercase_RepositoryIsCalledWithLowercaseBarcode()
        {
            Assert.Fail("Not yet implemented");
        }
    }

    class ProductRepositoryDouble : IProductRepository
    {
        private readonly Product product;

        public ProductRepositoryDouble(Product product)
        {
            this.product = product;
        }

        public Product GetProduct(string code)
        {
            return product;
        }
    }
}
