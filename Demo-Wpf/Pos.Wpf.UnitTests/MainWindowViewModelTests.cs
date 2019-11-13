using System;
using System.Collections.Generic;
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
        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            FakeScanner scannerSub = new FakeScanner();
            FakeRepository repStub = new FakeRepository(new[] {new Product {Barcode = "some barcode", CatalogCode = "SomeProductCode"}});
            MainWindowViewModel vm = new MainWindowViewModel(scannerSub, repStub);

            scannerSub.Scan("some barcode");

            Assert.AreEqual("SomeProductCode", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_PriceFormatted()
        {
            FakeScanner scannerStub = new FakeScanner();
            var testData = new[] {new Product {Barcode = "some barcode", Price = 14.131m}};
            Mock<IRepository> repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(r => r.GetEntities<Product>()).Returns(testData.AsQueryable);

            MainWindowViewModel vm = new MainWindowViewModel(scannerStub, repositoryStub.Object);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("14.13 $", vm.ProductPrice);
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

        class FakeRepository : IRepository
        {
            private readonly IEnumerable<Product> products;

            public FakeRepository(IEnumerable<Product> products)
            {
                this.products = products;
            }

            public IQueryable<T> GetEntities<T>() where T : class
            {
                return products.Cast<T>().AsQueryable();
            }
        }
    }
}
