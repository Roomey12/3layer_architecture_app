using AutoMapper;
using Epam5.ADODAL.ADO;
using Epam5.ADODAL.Entities;
using Epam5.ADODAL.Interfaces;
using Epam5.BLL.DTO;
using Epam5.BLL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam5.BLL.Services
{
    public class ADOService : Database, IService
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

        public ADOService(IUnitOfWork uow)
        {
            Database = uow;

            Products = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
            Vendors = mapper.Map<IEnumerable<Vendor>, List<VendorDTO>>(Database.Vendors.GetAll());
            Categories = mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(int categoryId)
        {
            OpenConnection();
            string sqlExpression = "Select * from Products" +
                    " Join Vendors ON Vendors.Id = Products.VendorId"+
                    " Where CategoryId = @categoryId";
            List<ProductDTO> products = new List<ProductDTO>();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    products.Add(new ProductDTO()
                    {
                        Id = (int)reader["Id"],
                        ProductName = (string)reader["ProductName"],
                        Price = (float)reader["Price"],
                        CategoryId = (int)reader["CategoryId"],
                        VendorId = (int)reader["VendorId"],
                        Vendor = (from v in Vendors where v.Id == (int)reader["VendorId"] select v).FirstOrDefault(),
                        Category = (from c in Categories where c.Id == (int)reader["CategoryId"] select c).FirstOrDefault()
                    }); 
                }
            }
            reader.Close();
            CloseConnection();
            return products;
        }

        public IEnumerable<ProductDTO> GetProductsByPrice(float price)
        {
            OpenConnection();
            string sqlExpression = "SELECT * FROM Products p " +
                    "JOIN Vendors v ON v.Id = p.VendorId " +
                    "Where Price > @price";
            List<ProductDTO> products = new List<ProductDTO>();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddWithValue("@price", price);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    products.Add(new ProductDTO()
                    {
                        Id = (int)reader["Id"],
                        ProductName = (string)reader["ProductName"],
                        Price = (float)reader["Price"],
                        CategoryId = (int)reader["CategoryId"],
                        VendorId = (int)reader["VendorId"],
                        Vendor = (from v in Vendors where v.Id == (int)reader["VendorId"] select v).FirstOrDefault(),
                        Category = (from c in Categories where c.Id == (int)reader["CategoryId"] select c).FirstOrDefault()
                    });
                }
            }
            reader.Close();
            CloseConnection();
            return products;
        }

        public IEnumerable<ProductDTO> GetProductsByVendor(int vendorId)
        {
            OpenConnection();
            string sqlExpression = "SELECT * FROM Products p " +
                    "JOIN Vendors v ON v.Id = p.VendorId " +
                    "Where v.Id = @vendorId";
            List<ProductDTO> products = new List<ProductDTO>();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddWithValue("@vendorId", vendorId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    products.Add(new ProductDTO()
                    {
                        Id = (int)reader["Id"],
                        ProductName = (string)reader["ProductName"],
                        Price = (float)reader["Price"],
                        CategoryId = (int)reader["CategoryId"],
                        VendorId = (int)reader["VendorId"],
                        Vendor = (from v in Vendors where v.Id == (int)reader["VendorId"] select v).FirstOrDefault(),
                        Category = (from c in Categories where c.Id == (int)reader["CategoryId"] select c).FirstOrDefault()
                    });
                }
            }
            reader.Close();
            CloseConnection();
            return products;
        }

        public IEnumerable<VendorDTO> GetVendorsByCategory(int categoryId)
        {
            OpenConnection();
            string sqlExpression = "SELECT Distinct v.VendorName, v.VendorCity, v.Id FROM Vendors v " +
                    "JOIN Products p ON p.VendorId = v.Id " +
                    "Where p.CategoryId = @categoryId";
            List<VendorDTO> vendors = new List<VendorDTO>();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    vendors.Add(new VendorDTO()
                    {
                        Id = (int)reader["Id"],
                        VendorName = (string)reader["VendorName"],
                        VendorCity = (string)reader["VendorCity"]
                    });
                }
            }
            reader.Close();
            CloseConnection();
            return vendors;
        }

        public IEnumerable<VendorDTO> GetVendorsByCity(string city)
        {
            OpenConnection();
            string sqlExpression = "Select * from Vendors Where VendorCity = @city";
            List<VendorDTO> vendors = new List<VendorDTO>();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.Parameters.AddWithValue("@city", city);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    vendors.Add(new VendorDTO()
                    {
                        Id = (int)reader["Id"],
                        VendorName = (string)reader["VendorName"],
                        VendorCity = (string)reader["VendorCity"]
                    });
                }
            }
            reader.Close();
            CloseConnection();
            return vendors;
        }

        public void OutputAllData()
        {
            foreach (var item in Categories)
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

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
