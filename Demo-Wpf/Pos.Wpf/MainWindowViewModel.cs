using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media.Effects;
using Microsoft.EntityFrameworkCore;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;

namespace Pos.Wpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IRepository rep;
        private readonly IScanner scanner;
        private readonly IPriceCalculator priceCalculator;

        public MainWindowViewModel(IScanner scanner, IRepository rep, IPriceCalculator priceCalculator)
        {
            this.scanner = scanner;
            this.rep = rep;
            this.priceCalculator = priceCalculator;
            this.scanner.BarcodeScanned += ScannerBarcodeScanned;

            this.Products = new ArrayList();
        }

        private void ScannerBarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            var product = rep.GetEntities<Product>().FirstOrDefault(p => p.Barcode == e.Barcode);
            if (product != null)
            {
                this.ProductCode = product.CatalogCode;
                decimal price = priceCalculator.GetPrice(product);
                ProductPrice = $"{price:F2} $";
            }
            else
            {
                this.ProductCode = "N/A";
            }
        }

        private string productCode;


        public string ProductCode
        {
            get { return productCode; }
            set
            {
                productCode = value;
                OnPropertyChanged();
            }
        }

        private string productName;


        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged();
            }
        }

        private string productPrice;

        public string ProductPrice
        {
            get { return productPrice; }
            set
            {
                productPrice = value;
                OnPropertyChanged();
            }
        }

        public ICollection Products { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ShowProducts(string productNameFilter = null)
        {
            IList<Product> products = rep.GetEntities<Product>()
                
                .Where(p => EF.)
                .OrderBy(p => p.CatalogName)
                
                .ToList();
            this.Products = new BindingList<Product>(products);
        }
    }
}
