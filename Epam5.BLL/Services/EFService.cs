using AutoMapper;
using Epam5.BLL.DTO;
using Epam5.BLL.Interfaces;
using Epam5.EFDAL.Entities;
using Epam5.EFDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam5.BLL.Services
{
    public class EFService : IService
    {
        IUnitOfWork Database { get; set; }

        List<ProductDTO> Products;
        List<VendorDTO> Vendors;
        List<CategoryDTO> Categories;

        IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>();
            cfg.CreateMap<Vendor, VendorDTO>();
            cfg.CreateMap<Product, ProductDTO>();
        }).CreateMapper();

        public EFService(IUnitOfWork uow)
        {
            Database = uow;

            Products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
            Vendors = mapper.Map<IEnumerable<Vendor>, List<VendorDTO>>(Database.Vendors.GetAll());
            Categories = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public void OutputAllData()
        {
            foreach(var item in Categories)
            {
                Console.WriteLine(item);
            }
            foreach (var item in Vendors)
            {
                Console.WriteLine(item);
            }
            foreach (var item in Products)
            {
                Console.WriteLine(item);
            }
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            return (from prod in Products where prod.CategoryId == categoryId select prod).Distinct();
        }

        public IEnumerable<VendorDTO> GetVendorsByCategory(int categoryId)
        {
            return (from prod in Products where prod.CategoryId == categoryId select prod.Vendor).Distinct();
        }

        public IEnumerable<ProductDTO> GetProductsByVendor(int vendorId)
        {
            return from prod in Products where prod.VendorId == vendorId select prod;
        }

        public IEnumerable<ProductDTO> GetProductsByPrice(float price)
        {
            return from prod in Products where prod.Price > price select prod;
        }

        public IEnumerable<VendorDTO> GetVendorsByCity(string city)
        {
            return from vend in Vendors where city == vend.VendorCity select vend;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
