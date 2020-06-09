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

        public MainWindowViewModel(IScanner scanner)
        {
            this.scanner = scanner;
            this.scanner.BarcodeScanned += ScannerBarcodeScanned;
        }

        private void ScannerBarcodeScanned(object sender, BarcodeScannedEventArgs e)
        {
            using (var db = new MyDbContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Barcode == e.Barcode);
                if (product != null)
                    ProductCode = product.CatalogCode;
                else
                {
                    ProductCode = "N/A";
                }
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
