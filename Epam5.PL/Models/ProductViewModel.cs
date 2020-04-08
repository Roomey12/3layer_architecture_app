using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.PL.Models
{
    class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
        public int VendorId { get; set; }
        public VendorViewModel Vendor { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id};\t{nameof(ProductName)}: {ProductName};" +
                   $"\t{nameof(Price)}: {Price}$;\t{nameof(Category.CategoryName)}: {Category.CategoryName};" +
                   $"\t{nameof(Vendor.VendorName)}: {Vendor.VendorName};";
        }
    }
}
