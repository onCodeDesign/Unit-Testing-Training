package pos;

import pos.BarcodeScanner.BarcodeScannedEvent;
import pos.BarcodeScanner.BarcodeScannedEventListener;
import pos.BarcodeScanner.Scanner;
import pos.dal.Product;
import pos.dal.ProductRepository;

public class MainWindowPresenter implements BarcodeScannedEventListener {
    private final Scanner scanner;
    private final ProductRepository productsRepository;

    private String productCode;
    private String productName;
    private String productPrice;

    public MainWindowPresenter(Scanner scanner, ProductRepository productsRepository) {
        this.scanner = scanner;
        this.productsRepository = productsRepository;
        scanner.addBarcodeScannedEventListener(this);
    }

    @Override
    public void BarcodeScanned(BarcodeScannedEvent event) {
        Product product = productsRepository.getProductByBarcode(event.getBarcode());

        if (product != null) {
            this.productCode = product.getCatalogCode();
            this.productPrice = String.format("%.2f $", product.getPrice()*1.19);
        } else {
            this.productCode = "N/A";
            this.productPrice = "N/A";
        }
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