using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.BLL.DTO
{
    public class VendorDTO
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public string VendorCity { get; set; }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id};\t{nameof(VendorName)}: {VendorName};" +
                   $"\t{nameof(VendorCity)}: {VendorCity};";
        }
    }
}
