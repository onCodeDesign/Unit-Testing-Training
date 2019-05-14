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
            Mock<IRepository> repository = GetRepositoryDouble(someProduct);

            ScannerDouble scanner = new ScannerDouble();
            MainWindowViewModel vm = GetTarget(scanner, repository);


            scanner.RaiseBarcodeScanned("any code");

            Assert.AreEqual("Some Code", vm.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_Raised_ScannedBarcodeIsSendToRepository()
        {
            Mock<IRepository> repositoryMock = GetRepositoryDouble();
            ScannerDouble scanner = new ScannerDouble();
            GetTarget(scanner, repositoryMock);

            scanner.RaiseBarcodeScanned("some barcode");

            repositoryMock.Verify(r => r.GetProduct("some barcode"));
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_PriceFormattedWithTwoDecimals()
        {
            Product product = new Product {Price = 13.356m};
            Mock<IRepository> productRep = GetRepositoryDouble(product);
            ScannerDouble scanner = new ScannerDouble();
            MainWindowViewModel vm = GetTarget(scanner, productRep);

            scanner.RaiseBarcodeScanned("some code");

            Assert.AreEqual("13.36 $", vm.ProductPrice);
        }

        private static Mock<IRepository> GetRepositoryDouble(Product someProduct = null)
        {
            someProduct = someProduct ?? new Product();

            Mock<IRepository> repository = new Mock<IRepository>();
            repository.Setup(r => r.GetProduct(It.IsAny<string>())).Returns(someProduct);
            return repository;
        }

        private static MainWindowViewModel GetTarget(ScannerDouble scanner, Mock<IRepository> repositoryMock)
        {
            Mock<IPriceCalculator> priceCalculatorStub = new Mock<IPriceCalculator>();
            priceCalculatorStub.Setup(p => p.GetPrice(It.IsAny<Product>())).Returns<Product>(p => p.Price);

            return new MainWindowViewModel(scanner, repositoryMock.Object, priceCalculatorStub.Object);
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