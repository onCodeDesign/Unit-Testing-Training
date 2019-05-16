using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pos.Wpf.Services;

namespace Pos.Wpf.UnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeIsDisplayed()
        {
            FakeScanner scanner = new FakeScanner();
            MainWindowViewModel vm = new MainWindowViewModel(scanner);

            scanner.RaiseBarcodeScanned("some code");

            Assert.AreEqual("some code", vm.ProductCode);
        }

        class FakeScanner : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void RaiseBarcodeScanned(string someCode)
            {
                BarcodeScanned?.Invoke(this, new BarcodeScannedEventArgs(someCode));
            }
        }
    }
}
