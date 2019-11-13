# Implement a POS (Point of Sale) system

Implement in an interactive way the following functionalities of a POS. When working on each point do NOT take into account the next functionalities that will come, but try to implement the current one as simple as possible. Later when new features are added refactor.

Keep the Code-Test cycle as short as possible. Refactor each time everything is green.

1. When a barcode is scanned the POS should display the product details
   a. Test that when a product exists the product code is displayed
   b. Test that when a product exists the price has currency symbol
   c. Test that when the barcode has upper case or spaces the repository is called with lower case and trim
   d. Test when product is not found
   
2. Add VAT to product price and display it. Implement it as easy as possible. Test it as easy as possible. The VAT rate is `19%`.
   a. Not all products have VAT. Add functionality to support product with and without VAT.


A product may have 0 or more taxes.
For simplicity we may represent taxes with a flag enum:
```
[Flags]
public enum TaxingType
{
    None = 0,
    Vat = 1,
    RegionalTax = 2,    
}
```

3. There are products which have a Regional Tax. The *Regional Tax* is `10%`. 
The products which have the *Regional Tax* are VAT exempt, even if they would have VAT

    Calculate the final price of a product by taking into account the regional tax as well.

    a. Test that the correct price is displayed for products with only VAT
    a. Test that the correct price is displayed for products which have VAT and Regional Tax


4. Some products are considered *Luxury Products*, and for these a Luxury Tax applies. This tax applies regardless of other taxes

    a. Test that the final price is correctly calculated for a product with 
    more taxes
    a. Test that for a product which has no taxes its catalog price is displayed

5. There are products for which we offer a discount of 50%. The discount is applied at the end from the total price.

6. The cashier may start a sale by pressing the *Start Sale* button. When a sale was created all the products that are scanned are part of that sale. 
 - each time a new product is scanned the *Sub Total* is also updated

7. The cashier may Close a running sale. The total will be displayed, when the sale is closed

8. The cashier may Cancel a running sale.

9. When closing a sale, the cashier may give a fixed amount as a discount to the buyer
  - the discount cannot be higher than 50% the the sale total

10. Show a list with all the sales ordered by status (Closed, or Canceled) and by date.
    a. Test that all sales are shown
    a. Test that the order by is applied

11. The cashier may put a sale OnHold and resume it later. When she does this she enters a unique name to the Sale. To resume a sale she needs to find it by name

--------------

12. Show a list with all the Products ordered by Name or Price.
    a. Test that all the products are shown
    2. Test the order is applied
    
13. Add a filter by Tax type to the products list
    