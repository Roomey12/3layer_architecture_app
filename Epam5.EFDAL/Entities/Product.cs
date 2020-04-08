using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.EFDAL.Entities
{
    public class Product
    {
        public static List<Product> ExistingProducts = new List<Product>();
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public Product(float price, string productName, Category category, Vendor vendor)
        {
            Price = price;
            ProductName = productName;
            Category = category;
            Vendor = vendor;
            ExistingProducts.Add(this);
        }
        public Product()
        {

        }
    }
}
