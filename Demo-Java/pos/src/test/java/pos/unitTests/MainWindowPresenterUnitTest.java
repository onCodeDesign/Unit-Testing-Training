package pos.unitTests;

import org.hibernate.SessionFactory;
import org.hibernate.collection.internal.PersistentList;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;
import pos.BarcodeScanner.BarcodeScannedEvent;
import pos.BarcodeScanner.BarcodeScannedEventListener;
import pos.BarcodeScanner.Scanner;
import pos.MainWindowPresenter;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

class MainWindowPresenterUnitTest {

    @Test
    void barcodeScanned_productExists_productCodeReturned() {
        //arrange
        FakeScanner scanner = new FakeScanner();
        MainWindowPresenter presenter = new MainWindowPresenter(scanner);

        //act
        scanner.scan("some code");

        //assert
        Assertions.assertEquals("some code", presenter.getProductCode());
    }

    class FakeScanner implements Scanner {

        private List<BarcodeScannedEventListener> eventListeners = new ArrayList<>();

        @Override
        public void addBarcodeScannedEventListener(BarcodeScannedEventListener eventListener) {
            eventListeners.add(eventListener);
        }

        public void scan(String someCode) {
            for ( BarcodeScannedEventListener eventListener : eventListeners) {
                eventListener.BarcodeScanned(new BarcodeScannedEvent(this, someCode));
            }
        }
    }
}