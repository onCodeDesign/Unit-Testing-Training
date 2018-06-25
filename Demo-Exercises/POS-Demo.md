# Implement a POS (Point of Sale) system

Implement in an interactive way the following functionalities of a POS. When working on each point do NOT take into account the next functionalities that will come, but try to implement the current one as simple as possible. Later when new features are added refactor.

Keep the Code-Test cycle as short as possible. Refactor each time everything is green.

1. When a barcode is scanned the POS should display the product details
   a. Test that when a product exists the product code is displayed
   b. Test that when a product exists the price has currency symbol
   c. Test that when the barcode has upper case or spaces the repository is called with lower case and trim
   d. Test when product is not found
   
2. Add VAT to product price and display it. Implement it as easy as possible. Test it as easy as possible. The VAT rate is `19%`

3. There products which also have a regional tax. For these products the final price is calculated by first adding the regional tax and then the VAT. The RegionalTax is `10%`

    Calculate the final price of a product by taking into account the regional tax as well.

    a. Test that the correct price is displayed for products with only VAT
    a. Test that the correct price is displayed for products with VAT and Regional Tax


4. A product may have different types of taxes and there may also be products which do not have VAT nor other taxes. The taxes are: `
The order in which taxes are applied is the following: *VAT*, *RegionalTax*, *LuxuryTax*. The *LuxuryTax* is the last one applied. The *LuxuryTax* is 

    a. Test that all taxes are applied for a product
    a. Test that the final price is correctly calculated for a product with 
    more taxes
    a. Test that for a product which has no taxes its catalog price is displayed


5. There are products for which we offer a discount of 50%. The discount is applied at the end. 

6. For some products and customers the discount may be more that the catalog price of the product. In this case the product should have the displayed proce `0` and not a negative value


7. The cashier may start a sale by pressing the *Start Sale* button. When a sale was created all the products that are scanned are part of that sale. 
At each point the cashier may ask for a *Sub Total* of the existing sale

8. The cashier may close a running sale. The total will be displayed.

9. Show a list with all the sales ordered by status (opened, or closed) and by date.
    a. Test that all sales are shown
    a. Test that the order by is applied
    
10. Add a filter by status to the sales list

--------------

11. Show a list with all the Products ordered by Name or Price.
    a. Test that all the products are shown
    2. Test the order is applied
    
12. Add a filter by Tax type to the products list
    