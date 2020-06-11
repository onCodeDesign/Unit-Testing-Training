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
        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeIsDisplayed()
        {
            ScannerTestDouble scannerStub = new ScannerTestDouble();
            Mock<IRepository> repStub = new Mock<IRepository>();
            Product[] testProducts = {new Product{Barcode = "some barcode", CatalogCode = "Some Code"}};
            repStub.Setup(r => r.GetEntities<Product>()).Returns(testProducts.AsQueryable);

            MainWindowViewModel vm = new MainWindowViewModel(scannerStub, repStub.Object);

            scannerStub.Scan("some barcode");
            
            Assert.AreEqual("Some Code", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_PriceFormatted()
        {
            ScannerTestDouble scannerStub = new ScannerTestDouble();
            var testProducts = new[] { new Product { Barcode = "some barcode", Price = 14.131m } };
            Mock<IRepository> repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(r => r.GetEntities<Product>()).Returns(testProducts.AsQueryable);

            MainWindowViewModel vm = new MainWindowViewModel(scannerStub, repositoryStub.Object);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("14.13 $", vm.ProductPrice);
        }

        [TestMethod]
        public void BarcodeScanned_ProductWithVat_VatIsApplied()
        {
            ScannerTestDouble scannerStub = new ScannerTestDouble();
            var testProducts = new[] { new Product { Barcode = "some barcode", Price = 10m, HasVat = true} };
            Mock<IRepository> repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(r => r.GetEntities<Product>()).Returns(testProducts.AsQueryable);

            MainWindowViewModel vm = new MainWindowViewModel(scannerStub, repositoryStub.Object);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("11.90 $", vm.ProductPrice);
        }


        sealed class ScannerTestDouble : IScanner
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
