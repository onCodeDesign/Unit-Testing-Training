package pos.unitTests;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import pos.BarcodeScanner.BarcodeScannedEvent;
import pos.BarcodeScanner.BarcodeScannedEventListener;
import pos.BarcodeScanner.Scanner;
import pos.MainWindowPresenter;
import pos.dal.Product;
import pos.dal.ProductRepository;

import java.util.ArrayList;
import java.util.List;

class MainWindowPresenterUnitTest {

    @Test
    void barcodeScanned_productExists_productCodeReturned() {
        //arrange
        FakeScanner scanner = new FakeScanner();
        ProductRepository repStub = new FakeProductRepository(getNewTestProduct("some barcode", "some code"));
        MainWindowPresenter presenter = new MainWindowPresenter(scanner, repStub);

        //act
        scanner.scan("some barcode");

        //assert
        Assertions.assertEquals("some code", presenter.getProductCode());
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

    private class FakeProductRepository implements ProductRepository {
        private Product product;

        private FakeProductRepository(Product product) {
            this.product = product;
        }

        @Override
        public Product getProductByBarcode(String barcode) {
            return product;
        }
    }
}