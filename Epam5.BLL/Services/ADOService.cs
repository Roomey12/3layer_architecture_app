using AutoMapper;
using Epam5.ADODAL.Entities;
using Epam5.ADODAL.Interfaces;
using Epam5.BLL.DTO;
using Epam5.BLL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.BLL.Services
{
    //public class ADOService : IService
    //{
    //    IUnitOfWork Database { get; set; }

    //    List<ProductDTO> Products;
    //    List<VendorDTO> Vendors;
    //    List<CategoryDTO> Categories;

    //    IMapper mapper = new MapperConfiguration(cfg =>
    //    {
    //        cfg.CreateMap<Category, CategoryDTO>();
    //        cfg.CreateMap<Vendor, VendorDTO>();

    //        cfg.CreateMap<Product, ProductDTO>();
    //    }).CreateMapper();

    //    public ADOService(IUnitOfWork uow)
    //    {
    //        Database = uow;

    //        Products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
    //        Vendors = mapper.Map<IEnumerable<Vendor>, List<VendorDTO>>(Database.Vendors.GetAll());
    //        Categories = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
    //    }

    //    public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
    //    {
    //        string sqlExpression = "Select * from Products " +
    //                "Where CategoryId = @categoryId";

    //        SqlCommand command = new SqlCommand(sqlExpression, connection);
    //        command.Parameters.AddWithValue("@input", input);
    //        SqlDataReader reader = command.ExecuteReader();

    //        if (reader.HasRows)
    //        {
    //            while (reader.Read())
    //            {
    //                Console.WriteLine(reader.GetValue(0));
    //            }
    //        }
    //    }

    //    public IEnumerable<ProductDTO> GetProductsByPrice(float price)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<ProductDTO> GetProductsByVendor(int vendorId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<VendorDTO> GetVendorsByCategory(int categoryId)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public IEnumerable<VendorDTO> GetVendorsByCity(string city)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void OutputAllData()
    //    {
    //        foreach (var item in Categories)
    //        {
    //            Console.WriteLine(item);
    //        }
    //        foreach (var item in Vendors)
    //        {
    //            Console.WriteLine(item);
    //        }
    //        foreach (var item in Products)
    //        {
    //            Console.WriteLine(item);
    //        }
    //    }

    //    public void Dispose()
    //    {
    //        Database.Dispose();
    //    }
    //}
}
