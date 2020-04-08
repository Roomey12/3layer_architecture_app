using Epam5.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam5.BLL.Interfaces
{
    public interface IService
    {
        void OutputAllData();
        IEnumerable<ProductDTO> GetProductsByCategory(int categoryId);
        IEnumerable<VendorDTO> GetVendorsByCategory(int categoryId);
        IEnumerable<ProductDTO> GetProductsByVendor(int vendorId);
        IEnumerable<ProductDTO> GetProductsByPrice(float price);
        IEnumerable<VendorDTO> GetVendorsByCity(string city);
        void Dispose();
    }
}
