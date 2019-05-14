using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Pos.Wpf.DAL;
using Pos.Wpf.Services;

namespace Pos.Wpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IScanner scanner;
        private readonly IRepository repository;

        public MainWindowViewModel(IScanner scanner, IRepository repository)
        {
            this.scanner = scanner;
            this.repository = repository;
            this.scanner.BarcodeScanned += ScannerBarcodeScanned;
        }

        private void ScannerBarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            var scannedBarcode = e.Barcode; //string.Empty check code coverage
            Product product = repository.GetProduct(scannedBarcode);
            if (product != null)
            {
                ProductCode = product.CatalogCode;
                var price = product.Price*1.19m;
                ProductPrice = $"{price:F2} $";
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
