using System;
using System.Collections.Generic;
using System.Linq;
using Pos.Wpf.DAL;

namespace Pos.Wpf
{
    public class Sale
    {
        private readonly List<SaleProduct> products = new List<SaleProduct>();

        public void Add(Product product, decimal salePrice)
        {
            products.Add(new SaleProduct(product, salePrice));
        }

        public decimal SubTotal => products.Sum(p => p.SalePrice);

        public decimal Total { get; private set; }

        public void Close(decimal discount)
        {
            decimal total = SubTotal;
            decimal halfAmount = total / 2;
            if (discount>halfAmount)
                throw new InvalidOperationException("The discount amount cannot be higher than 50% of the total amount.");

            Total = total - discount;
        }

        class SaleProduct
        {
            public SaleProduct(Product product, decimal salePrice)
            {
                Product = product;
                SalePrice = salePrice;
            }

            public Product Product { get; }
            public decimal SalePrice { get; }
        }
    }
}