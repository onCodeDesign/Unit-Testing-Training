using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            //arrange
            FakeScanner scanner = new FakeScanner();
            MainWindowViewModel vm = new MainWindowViewModel(scanner);
            
            //act
            scanner.Scan("some code");
            
            // assert
            Assert.AreEqual("some code", vm.ProductCode);
        }
    }

    public class FakeScanner : IScanner
    {
        public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

        protected virtual void OnBarcodeScanned(BarcodeScannedEventArgs e)
        {
            BarcodeScanned?.Invoke(this, e);
        }

        public void Scan(string someCode)
        {
            OnBarcodeScanned(new BarcodeScannedEventArgs(someCode));
        }
    }
}
