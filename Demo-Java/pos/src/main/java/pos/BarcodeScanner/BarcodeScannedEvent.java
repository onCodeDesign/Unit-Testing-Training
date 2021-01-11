package pos.BarcodeScanner;

import java.util.EventObject;

public class BarcodeScannedEvent extends EventObject {
    private String barcode;

    public BarcodeScannedEvent(Object source, String barcode) {
        super(source);
        this.barcode = barcode;
    }

    public String getBarcode() {
        return barcode;
    }
}
