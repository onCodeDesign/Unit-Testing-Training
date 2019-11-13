using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        private FakeScanner scannerSub;

        [TestInitialize]
        public void TestInitialize()
        {
            scannerSub = new FakeScanner();
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            Product testDataProduct = new Product {Barcode = "some barcode", CatalogCode = "SomeProductCode"};
            IRepository repStub = GetRepositoryStub(testDataProduct);
            MainWindowViewModel vm = GetTarget(repStub);

            scannerSub.Scan("some barcode");

            Assert.AreEqual("SomeProductCode", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_PriceFormatted()
        {
            var testDataProduct = new Product {Barcode = "some barcode", Price = 14.131m};
            IRepository repositoryStub = GetRepositoryStub(testDataProduct);
            MainWindowViewModel vm = GetTarget(repositoryStub);

            scannerSub.Scan("some barcode");

            Assert.AreEqual("14.13 $", vm.ProductPrice);
        }

        [TestMethod]
        public void BarcodeScanned_ProductWithVat_VatCalculated()
        {
            var testDataProduct = new Product { Barcode = "some barcode", HasVat = true, Price = 10m };
            IRepository repositoryStub = GetRepositoryStub(testDataProduct);
            MainWindowViewModel vm = GetTarget(repositoryStub);

            scannerSub.Scan("some barcode");

            Assert.AreEqual("11.90 $", vm.ProductPrice);
        }

        private static IRepository GetRepositoryStub(params Product[] products)
        {
            Mock<IRepository> repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(r => r.GetEntities<Product>()).Returns(products.AsQueryable);
            return repositoryStub.Object;
        }

        private MainWindowViewModel GetTarget(IRepository repositoryStub)
        {
            return new MainWindowViewModel(scannerSub, repositoryStub);
        }

        sealed class FakeScanner : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void Scan(string someBarcode)
            {
                OnBarcodeScanned(new BarcodeScannedEventArgs(someBarcode));
            }

            private void OnBarcodeScanned(BarcodeScannedEventArgs e)
            {
                BarcodeScanned?.Invoke(this, e);
            }
        }
    }
}
