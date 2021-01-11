package pos.BarcodeScanner;

import java.util.EventListener;

public interface BarcodeScannedEventListener extends EventListener {
    void BarcodeScanned(BarcodeScannedEvent event);
}
