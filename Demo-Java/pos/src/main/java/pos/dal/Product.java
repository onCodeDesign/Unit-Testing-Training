package pos.dal;

public class Product {
    private String barcode;
    private String catalogCode;
    private String catalogName;
    private Double price;
    private boolean hasVat;

    public Product() {
    }

    public String getBarcode() { return barcode; }
    public void setBarcode(String barcode) { this.barcode = barcode; }

    public String getCatalogCode() { return catalogCode; };
    public void setCatalogCode(String catalogCode) { this.catalogCode = catalogCode; }

    public String getCatalogName() { return catalogName; }
    public void setCatalogName(String catalogName) { this.catalogName = catalogName; }

    public Double getPrice() { return price; }
    public void setPrice(Double price) {
        this.price = price;
    }

    public boolean hasVat() { return hasVat; }
    public void setHasVat(boolean hasVat) { this.hasVat = hasVat; }
}
