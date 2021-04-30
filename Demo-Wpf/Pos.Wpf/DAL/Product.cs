using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Wpf.DAL
{
    public class Product
    {
        public string Barcode { get; set; }
        public string CatalogCode { get; set; }
        public string CatalogName { get; set; }
        public decimal Price { get; set; }
        public TaxationType[] Taxes { get; set; } = new TaxationType[0];
        public GoodsCategory Category { get; set; } = GoodsCategory.Convenience;
    }

    public enum TaxationType
    {
        Vat,
        RegionalTax,
        LuxuryTax
    }

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
}