package pos;

import pos.BarcodeScanner.BarcodeScannedEvent;
import pos.BarcodeScanner.BarcodeScannedEventListener;
import pos.BarcodeScanner.Scanner;

public class MainWindowPresenter implements BarcodeScannedEventListener {
    private Scanner scanner;

    private String productCode;
    private String productName;
    private String productPrice;

    public MainWindowPresenter(Scanner scanner) {
        this.scanner = scanner;
        scanner.addBarcodeScannedEventListener(this);
    }

    @Override
    public void BarcodeScanned(BarcodeScannedEvent event) {

    }

    public String getProductCode() {
        return productCode;
    }

    public String getProductName() {
        return productName;
    }

    public String getProductPrice() {
        return productPrice;
    }
}