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
        FakeScanner scanner;

        [TestInitialize]
        public void TestInitialize()
        {
            scanner = new FakeScanner();
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_ProductCodeDisplayed()
        {
            Product[] testDataProducts =
            {
                new Product
                {
                    Barcode = "any product barcode",
                    CatalogCode = "Some code"
                },
            };
            var repositoryStub = CreateRepositoryStub(testDataProducts);
            MainWindowViewModel target = GetTarget(repositoryStub);


            scanner.Scan("any product barcode");

            Assert.AreEqual("Some code", target.ProductCode);
        }

        [TestMethod]
        public void BarcodeScanned_ProductExists_PriceFormattedAndVatApplied()
        {
            Product[] testDataProducts = {new Product {Barcode = "some barcode", HasVat = true, Price = 14.13m},};
            var repositoryStub = CreateRepositoryStub(testDataProducts);

            MainWindowViewModel target = GetTarget(repositoryStub);

            scanner.Scan("some barcode");

            Assert.AreEqual("16.81 $", target.ProductPrice);
        }

        private MainWindowViewModel GetTarget(IRepository repositoryStub)
        {
            return new MainWindowViewModel(scanner, repositoryStub);
        }

        private static IRepository CreateRepositoryStub(Product[] testDataProducts)
        {
            Mock<IRepository> repositoryStub = new Mock<IRepository>();
            repositoryStub.Setup(r => r.GetEntities<Product>())
                .Returns(testDataProducts.AsQueryable);
            return repositoryStub.Object;
        }

        sealed class FakeScanner : IScanner
        {
            public event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;

            public void Scan(string barcode)
            {
                OnBarcodeScanned(new BarcodeScannedEventArgs(barcode));
            }

            private void OnBarcodeScanned(BarcodeScannedEventArgs e)
            {
                BarcodeScanned?.Invoke(this, e);
            }
        }
    }
}