package pos.unitTests;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import pos.BarcodeScanner.BarcodeScannedEvent;
import pos.BarcodeScanner.BarcodeScannedEventListener;
import pos.BarcodeScanner.Scanner;
import pos.MainWindowPresenter;
import pos.dal.Product;
import pos.dal.ProductRepository;
import static org.mockito.Mockito.*;

import java.util.ArrayList;
import java.util.List;


class MainWindowPresenterUnitTest {
    private FakeScanner scanner;

    @BeforeEach
    void initialize() {
        scanner = new FakeScanner();
    }

    @Test
    void barcodeScanned_productExists_productCodeReturned() {
        Product testData = getNewTestProduct("some barcode", "some code");
        ProductRepository repStub = getRepositoryStub(testData);
        MainWindowPresenter target = getTarget(repStub);

        scanner.scan("some barcode");

        Assertions.assertEquals("some code", target.getProductCode());
    }

    @Test
    void barcodeScanned_productExists_priceFormatted() {
        Product testData = getNewTestProduct("some barcode", 14.131);
        ProductRepository repStub = getRepositoryStub(testData);
        MainWindowPresenter target = getTarget(repStub);

        scanner.scan("some barcode");

        Assertions.assertEquals("14.13 $", target.getProductPrice());
    }

    private ProductRepository getRepositoryStub(Product testData) {
        ProductRepository repStub = mock(ProductRepository.class);
        when(repStub.getProductByBarcode(any(String.class))).thenReturn(testData);
        return repStub;
    }

    private MainWindowPresenter getTarget(ProductRepository repStub) {
        return new MainWindowPresenter(scanner, repStub);
    }

    private Product getNewTestProduct(String barcode, double price) {
        Product p = new Product();
        p.setBarcode(barcode);
        p.setPrice(price);
        return  p;
    }

    private Product getNewTestProduct(String barcode, String code) {
        Product p = new Product();
        p.setBarcode(barcode);
        p.setCatalogCode(code);
        return  p;
    }

    private class FakeScanner implements Scanner {
        private List<BarcodeScannedEventListener> eventListeners = new ArrayList<>();

        @Override
        public void addBarcodeScannedEventListener(BarcodeScannedEventListener eventListener) {
            eventListeners.add(eventListener);
        }

        public void scan(String barcode) {
            for (BarcodeScannedEventListener eventListener : eventListeners) {
                eventListener.BarcodeScanned(new BarcodeScannedEvent(this, barcode));
            }
        }
    }
}