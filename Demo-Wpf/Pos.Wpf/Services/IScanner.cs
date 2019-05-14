using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Wpf.Services
{
    public interface IScanner
    {
        event EventHandler<BarcodeScannedEventArgs> BarcodeScanned;
    }
}
