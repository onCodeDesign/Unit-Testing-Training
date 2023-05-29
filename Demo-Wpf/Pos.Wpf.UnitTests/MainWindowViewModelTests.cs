using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            Product product = new Product { CatalogCode = "product code", Barcode = "some barcode" };
            RepositoryDouble repository = new RepositoryDouble(product);
            ScannerDouble scannerStub = new ScannerDouble();
            MainWindowViewModel vm = new MainWindowViewModel(scannerStub, repository);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("product code", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductExist_PriceFormatted()
        {
            Product product = new Product { Barcode = "some barcode", Price = 14.131m };

            ScannerDouble scanner = new ScannerDouble();
            RepositoryDouble repository = new RepositoryDouble(product);
            MainWindowViewModel vm = new MainWindowViewModel(scanner, repository);

            scanner.Scan("some barcode");

            Assert.AreEqual("14.13 $", vm.ProductPrice);
        }


        private class ScannerDouble : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void Scan(string barcode)
            {
                BarcodeScanned?.Invoke(this, new BarcodeScannedEventArgs(barcode));
            }
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
