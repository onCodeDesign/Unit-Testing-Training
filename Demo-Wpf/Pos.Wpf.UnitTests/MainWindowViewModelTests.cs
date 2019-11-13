using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            FakeScanner scanner = new FakeScanner();
            FakeRepository repStub = new FakeRepository(new[] {new Product {Barcode = "some barcode", CatalogCode = "SomeProductCode"}});
            MainWindowViewModel vm = new MainWindowViewModel(scanner, repStub);

            scanner.Scan("some barcode");

            Assert.AreEqual("SomeProductCode", vm.ProductCode);
        }

        class FakeScanner : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void Scan(string someBarcode)
            {
                OnBarcodeScanned(new BarcodeScannedEventArgs(someBarcode));
            }

            protected virtual void OnBarcodeScanned(BarcodeScannedEventArgs e)
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
