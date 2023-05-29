package pos.dal;

public interface ProductRepository {
    Product getProductByBarcode(String barcode);
}
