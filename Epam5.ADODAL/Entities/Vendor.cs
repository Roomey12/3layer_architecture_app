using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.ADODAL.Entities
{
    public class Vendor
    {
        public static List<Vendor> ExistingVendors = new List<Vendor>();
        public int Id { get; set; }
        public string VendorName { get; set; }
        public string VendorCity { get; set; }
        public List<Product> VendorProducts { get; set; }
        public Vendor(string vendorName, string vendorCity)
        {
            VendorName = vendorName;
            VendorCity = vendorCity;
            ExistingVendors.Add(this);
        }
        public Vendor()
        {

        }
    }
}
