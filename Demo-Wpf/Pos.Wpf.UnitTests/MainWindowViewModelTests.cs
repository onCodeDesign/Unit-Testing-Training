using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private FakeScanner scanner;

        [TestInitialize]
        public void TestInitialize()
        {
            scanner = new FakeScanner();
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeIsDisplayed()
        {
            Product product = new Product { CatalogCode = "some test code" };
            var repository = GetRepository(product);
            MainWindowViewModel vm = GetTarget(scanner, repository);


            scanner.RaiseBarcodeScanned("any code");

            Assert.AreEqual("some test code", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductNotExists_NotAvailable()
        {
            IRepository repository = GetRepository();
            var vm  = GetTarget(scanner, repository);

            scanner.RaiseBarcodeScanned("any code");

            Assert.AreEqual("N/A", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_EventRaised_ScannedValueSentToDb()
        {
            Mock<IRepository> repMock = new Mock<IRepository>();
            GetTarget(scanner, repMock.Object);

            scanner.RaiseBarcodeScanned("some barcode");

            repMock.Verify(r=>r.GetProduct("some barcode"));
        }

        [TestMethod]
        public void BarcodeScanned_ProductExistsAndHasVat_PriceFormattedAndVatAdded()
        {
            Product product = new Product {Price = 13.35m, HasVat = true};
            IRepository repository = GetRepository(product);
            MainWindowViewModel vm = GetTarget(repository);

            scanner.RaiseBarcodeScanned("any code");

            Assert.AreEqual("11.90 $", vm.ProductPrice);
        }

        [TestMethod]
        public void BarcodeScanned_ProductExistsAndNotVat_PriceFormattedAndVatNotAdded()
        {
            Product product = new Product { Price = 10m, HasVat = false };
            IRepository repository = GetRepository(product);
            MainWindowViewModel vm = GetTarget(repository);

            scanner.RaiseBarcodeScanned("any code");

            Assert.AreEqual("10.00 $", vm.ProductPrice);
        }

        private static IRepository GetRepository(Product product=null)
        {
            IRepository repository = new RepositoryDouble(product);
            return repository;
        }

        private MainWindowViewModel GetTarget(IRepository repository)
        {
            return GetTarget(this.scanner, repository);
        }

        private MainWindowViewModel GetTarget(IScanner scannerParam, IRepository repository)
        {
            return new MainWindowViewModel(scannerParam, repository);

        }

        class FakeScanner : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void RaiseBarcodeScanned(string someCode)
            {
                BarcodeScanned?.Invoke(this, new BarcodeScannedEventArgs(someCode));
            }
        }

        class RepositoryDouble : IRepository
        {
            private readonly Product product;

            public RepositoryDouble(Product product)
            {
                this.product = product;
            }

            public Product GetProduct(string productBarcode)
            {
                return product;
            }
        }
    }
}
