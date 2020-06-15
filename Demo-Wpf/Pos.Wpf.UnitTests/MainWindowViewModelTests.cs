using System;
using System.Collections;
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

            MainWindowViewModel vm = GetTarget(scannerStub, repStub);

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

            MainWindowViewModel vm = GetTarget(scannerStub, repositoryStub);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("14.13 $", vm.ProductPrice);
        }

        [TestMethod]
        public void BarcodeScanned_ProductNotExists_ProductCodeNotAvailable()
        {
            ScannerTestDouble scannerStub = new ScannerTestDouble();
            Mock<IRepository> repStub = new Mock<IRepository>();
            Product[] testProducts = new Product[0];
            repStub.Setup(r => r.GetEntities<Product>()).Returns(testProducts.AsQueryable);

            MainWindowViewModel vm = GetTarget(scannerStub, repStub);

            scannerStub.Scan("some barcode");

            Assert.AreEqual("N/A", vm.ProductCode);
        }

        [TestMethod]
        public void ShowProducts_MoreProducts_ProductsOrderByName()
        {
            ScannerTestDouble scannerStub = new ScannerTestDouble();
            Mock<IRepository> repStub = new Mock<IRepository>();
            Product[] testData =
            {
                new Product {CatalogName = "Mouse"},
                new Product {CatalogName = "Keyboard"},
            };
            repStub.Setup(r => r.GetEntities<Product>())
                .Returns(testData.AsQueryable);

            MainWindowViewModel vm = GetTarget(scannerStub, repStub);

            
            vm.ShowProducts();
            
            ICollection actualProducts = vm.Products;
            Product[] expectedProducts = 
            {
                new Product {CatalogName = "Keyboard"},
                new Product {CatalogName = "Mouse"}
            };
            CollectionAssert.AreEqual(expectedProducts, actualProducts);
        }

        [TestMethod]
        public void ShowProducts_FilterByName_ProductsAreFiltered()
        {
            ScannerTestDouble scannerStub = new ScannerTestDouble();
            Mock<IRepository> repStub = new Mock<IRepository>();
            Product[] testData =
            {
                new Product {CatalogName = "Mouse"},
                new Product {CatalogName = "Keyboard"},
            };
            repStub.Setup(r => r.GetEntities<Product>())
                .Returns(testData.AsQueryable);

            MainWindowViewModel vm = GetTarget(scannerStub, repStub);


            vm.ShowProducts("Mo");

            ICollection actualProducts = vm.Products;
            Product[] expectedProducts =
            {
                new Product {CatalogName = "Mouse"}
            };
            CollectionAssert.AreEqual(expectedProducts, actualProducts);
        }

        private static MainWindowViewModel GetTarget(ScannerTestDouble scannerStub, Mock<IRepository> repStub)
        {
            Mock<IPriceCalculator> priceCalculatorStub = new Mock<IPriceCalculator>();
            priceCalculatorStub.Setup(c => c.GetPrice(It.IsAny<Product>())).Returns<Product>(p => p.Price);
            return new MainWindowViewModel(scannerStub, repStub.Object, priceCalculatorStub.Object);
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
