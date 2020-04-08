using Epam5.EFDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public int VendorId { get; set; }
        public VendorDTO Vendor { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id};\t{nameof(ProductName)}: {ProductName};" +
                   $"\t{nameof(Price)}: {Price}$;\t{nameof(CategoryDTO.CategoryName)}: {Category.CategoryName};" +
                   $"\t{nameof(VendorDTO.VendorName)}: {Vendor.VendorName};";
        }
    }
}
