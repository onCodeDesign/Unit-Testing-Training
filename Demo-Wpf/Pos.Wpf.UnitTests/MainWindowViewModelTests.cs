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
            ScannerDouble scannerStub = new ScannerDouble();
            MainWindowViewModel vm = new MainWindowViewModel(scannerStub);
            
            //act
            scannerStub.Scan("product code");
            
            // assert
            Assert.AreEqual("product code", vm.ProductCode);
        }
    }

    public class ScannerDouble : IScanner
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
