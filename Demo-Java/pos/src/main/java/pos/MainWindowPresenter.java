package pos;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import pos.BarcodeScanner.BarcodeScannedEvent;
import pos.BarcodeScanner.BarcodeScannedEventListener;
import pos.BarcodeScanner.Scanner;
import pos.dal.HibernateUtil;
import pos.dal.Product;

import java.util.List;

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
        Session session = HibernateUtil.getCurrentSessionFactory().getCurrentSession();
        session.beginTransaction();

        List<Product> productList =  session.createQuery("from Product as p where p.barcode = :barcode", Product.class)
                .setParameter(":barcode", event.getBarcode())
                .list();

        if (productList.size() > 0) {
            Product product = productList.get(0);
            this.productCode = product.getCatalogCode();
        } else {
            this.productCode = "N/A";
        }

        session.getTransaction().commit();
        session.close();
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