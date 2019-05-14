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
        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            Product someProduct = new Product {CatalogCode = "Some Code"};

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(r => r.GetProduct(It.IsAny<string>())).Returns(someProduct);

            ScannerDouble scanner = new ScannerDouble();
            MainWindowViewModel vm = new MainWindowViewModel(scanner, repository.Object);

            scanner.RaiseBarcodeScanned("any code");

            Assert.AreEqual("Some Code", vm.ProductCode);
        }

        sealed class ScannerDouble : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void RaiseBarcodeScanned(string someCode)
            {
                OnBarcodeScanned(new BarcodeScannedEventArgs(someCode));
            }

            private void OnBarcodeScanned(BarcodeScannedEventArgs e)
            {
                BarcodeScanned?.Invoke(this, e);
            }
        }
    }
}
