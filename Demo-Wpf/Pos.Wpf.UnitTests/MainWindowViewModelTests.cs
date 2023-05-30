using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private ScannerDouble scannerStub;


        [TestInitialize]
        public void TestInitialize()
        {
            scannerStub = new ScannerDouble();
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            Product product = new Product { CatalogCode = "product code", Barcode = "some barcode"};
            IRepository repositoryStub = GetRepositoryDouble(product);
            MainWindowViewModel vm = GetTarget(repositoryStub);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("product code", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductWithout_PriceFormatted()
        {
            Product product = new Product { Price = 14.131m, Barcode = "some barcode"};
            IRepository repository = GetRepositoryDouble(product);
            MainWindowViewModel vm = GetTarget(repository);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("14.13 $", vm.ProductPrice);
        }

        private MainWindowViewModel GetTarget(IRepository repository)
        {
            var priceCalculatorStub = new Mock<IPriceCalculator>();
            priceCalculatorStub.Setup(p => p.GetPrice(It.IsAny<Product>()))
                .Returns<Product>(p => p.Price);

            return new MainWindowViewModel(scannerStub, repository, priceCalculatorStub.Object);
        }

        private class ScannerDouble : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void Scan(string barcode)
            {
                BarcodeScanned?.Invoke(this, new BarcodeScannedEventArgs(barcode));
            }
        }

        private static IRepository GetRepositoryDouble(Product product)
        {
            var repoStub = new Mock<IRepository>();
            repoStub.Setup(x => x.GetEntities<Product>())
                .Returns(new[] {product}.AsQueryable());
            return repoStub.Object;
        }

        public class RepositoryDouble : IRepository
        {
            private readonly Product[] product;

            public RepositoryDouble(params Product[] product)
            {
                this.product = product;
            }

            public IQueryable<T> GetEntities<T>() where T : class
            {
                return product.Cast<T>().AsQueryable();
            }
        }
    }
}
