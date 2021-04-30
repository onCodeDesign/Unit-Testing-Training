# Implement a POS (Point of Sale) system

Implement in an interactive way the following functionalities of a POS. When working on each point do NOT take into account the next functionalities that will come, but try to implement the current one as simple as possible. Later when new features are added refactor.

Keep the Code-Test cycle as short as possible. Refactor each time everything is green.

1. When a barcode is scanned the POS should display the product details
   a. Test that when a product exists the product code is displayed
   b. Test that when a product exists the price is formatted with a currency symbol and two decimals. Ex. Product.Price=14.131 => '14.13 $'
   c. Test that when the barcode has upper case or spaces the repository is called with lower case and trim
   d. Test when product is not found
   
2. Add VAT to product price and display it. 
    a. Implement it as easy as possible. Test it as easy as possible. 
        The VAT rate is fixed and the same for all products to `19%`.
    b. Not all products have VAT. Add functionality to support product with and without VAT.


A product may have different taxation types. For simplicity we may represent them with an enum:

```
public enum TaxationType
{
     Vat,
     RegionalTax,
     LuxuryTax
}

public class Product
{
    //...
    public TaxationType[] Taxes { get; set; }
}

```

3. There are products which have a Regional Tax. The *Regional Tax* is `10%`. 
The products which have the *Regional Tax* are VAT exempt, even if they have VAT

    Calculate the final price of a product by taking into account the regional tax as well.

    a. Test that the correct price is displayed for products with only VAT
    a. Test that the correct price is displayed for products which have VAT and Regional Tax
    a. Test that for a product which has no taxes its catalog price is displayed



4. Some products are considered *Luxury Products*, and for these a Luxury Tax applies.
    Luxury tax calculation depends on product goods category. We consider these categories:

```
public enum GoodsCategory
{
    /// <summary>
    /// Specialty goods have particularly unique characteristics and brand identifications for which a significant group of buyers is willing to make a special purchasing effort.
    /// <para>
    ///     Examples include specific brands of fancy products, luxury cars, professional photographic equipment, and high-fashion clothing.
    /// </para>
    /// </summary>
    Specialty,

    /// <summary>
    /// Convenience goods are those that are regularly consumed and are readily available for purchase.
    /// <para>
    ///     These goods are mostly sold by wholesalers and retailers and include items such as milk and tobacco products.
    /// </para>
    /// </summary>
    Convenience,

    /// <summary>
    /// Shopping goods are those in which a purchase requires more thought and planning than with convenience goods
    /// <para>
    ///     Shopping goods are more expensive and have more durability and longer lifespans than convenience goods
    ///     Shopping goods include furniture and televisions.
    /// </para>
    /// </summary>
    Shopping
}
```
    Luxury tax calculates as follows:
        - for all the products that are cheaper than 100, the tax is 15%
        - for products with price between 35 - 70k, the tax is 100% for Specialties and 75% for the rest
        - for products that are more expensive the 70k:
            - for Specialties is 180% on top of the price with the Regional Tax applied if that products has a RegionalTax
            - for Shopping is 180% on top of the catalog price
            - for the other is 150%
    Calculate price of products w/ luxury tax as specified above.
            
5. Test price calculation for product w/ luxury tax
    a. Test for a Product with LuxuryTax and price 99
    a. Test for a Product with Regional and Luxury taxes, price above 100k, and in Specialty category

6. Why is it difficult to name and write GOOD Unit Tests for Price Calculator?
   Refactor PriceCalculator to separate the logic to decide which taxes should be applied for a product from the logic to calculate each tax.

    a. Rewrite existent PriceCalculatorTests that verify which taxes should be applied for a product in TaxesFactoryTests. 
       Have a test that checks the case of a product with both RegionalTax and VAT, only Regional Tax will be applied
    a. Have a test for products with no taxes
    a. Have a test that verifies that for a product with all three taxes, only Regional and Luxury are returned
    a. Rewrite the all tests from PriceCalculatorTests to TaxesFactoryTests and specific tax calculators


7. There are products for which we offer a discount of 50%. The discount is applied at the end from the total price.

8. The cashier may start a sale by pressing the *Start Sale* button. When a sale was created all the products that are scanned are part of that sale. 
 - each time a new product is scanned the *Sub Total* is also updated

9. The cashier may Close a running sale. The total will be displayed, when the sale is closed

10. The cashier may Cancel a running sale.

11. When closing a sale, the cashier may give a fixed amount as a discount to the buyer
  - the discount cannot be higher than 50% the the sale total

12. Show a list with all the sales ordered by status (Closed, or Canceled) and by date.
    a. Test that all sales are shown
    a. Test that the order by is applied

13. The cashier may put a sale OnHold and resume it later. When she does this she enters a unique name to the Sale. To resume a sale she needs to find it by name

--------------

14. Show a list with all the Products ordered by Name or Price.
    a. Test that all the products are shown
    2. Test the order is applied
    
15. Add a filter by Tax type to the products list
    