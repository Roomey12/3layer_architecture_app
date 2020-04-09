using Epam5.ADODAL.ADO;
using Epam5.ADODAL.Entities;
using Epam5.ADODAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam5.ADODAL.Repositories
{
    class ProductRepository : Database, IRepository<Product>
    {
        public void Delete(Product product)
        {
            OpenConnection();
            string name = product.ProductName;
            float price = product.Price;
            int categoryId = product.CategoryId;
            int vendorId = product.VendorId;
            string sqlExpression = "DELETE FROM Products WHERE ProductName = @name AND" +
                " Price = @price AND CategoryId = @categoryId AND VendorId = @vendorId";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            SqlParameter priceParam = new SqlParameter("@price", price);
            command.Parameters.Add(priceParam);
            SqlParameter categoryIdParam = new SqlParameter("@categoryId", categoryId);
            command.Parameters.Add(categoryIdParam);
            SqlParameter vendorIdParam = new SqlParameter("@vendorId", vendorId);
            command.Parameters.Add(vendorIdParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public IEnumerable<Product> GetAll()
        {
            VendorRepository v = new VendorRepository();
            var Vendors = v.GetAll();
            CategoryRepository c = new CategoryRepository();
            var Categories = c.GetAll();
            List<Product> products = new List<Product>();
            OpenConnection();
            string sqlExpression = "Select * From Products";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        Id = (int)reader["Id"],
                        ProductName = (string)reader["ProductName"],
                        Price = (float)reader["Price"],
                        CategoryId = (int)reader["CategoryId"],
                        VendorId = (int)reader["VendorId"],
                        Vendor = Vendors.Where(x=>x.Id == (int)reader["VendorId"]).FirstOrDefault(),
                        Category = Categories.Where(x=>x.Id == (int)reader["CategoryId"]).FirstOrDefault()
                    });
                }
            }
            reader.Close();
            CloseConnection();
            return products;
        }

        public Product GetById(int id)
        {
            OpenConnection();
            string sqlExpression = "Select * From Products Where Id = @id";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();
            Product product = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    product = new Product()
                    {
                        Id = (int)reader["Id"],
                        ProductName = (string)reader["VendorName"],
                        Price = (float)reader["Price"],
                        CategoryId = (int)reader["CategoryId"],
                        VendorId = (int)reader["VendorId"]
                    };
                }
            }
            reader.Close();
            CloseConnection();
            return product;
        }

        public void Insert(Product product)
        {
            OpenConnection();
            string name = product.ProductName;
            float price = product.Price;
            int categoryId = product.CategoryId;
            int vendorId = product.VendorId;
            string sqlExpression = "INSERT INTO Products (ProductName, Price, CategoryId, VendorId)" +
                " VALUES (@name, @price, @categoryId, @vendorId)";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            SqlParameter priceParam = new SqlParameter("@price", price);
            command.Parameters.Add(priceParam);
            SqlParameter categoryIdParam = new SqlParameter("@categoryId", categoryId);
            command.Parameters.Add(categoryIdParam);
            SqlParameter vendorIdParam = new SqlParameter("@vendorId", vendorId);
            command.Parameters.Add(vendorIdParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Update(Product product)
        {
            OpenConnection();
            string name = product.ProductName;
            float price = product.Price;
            int categoryId = product.CategoryId;
            int vendorId = product.VendorId;
            string sqlExpression = "Update Products SET ProductName = @name, " +
                "Price = @price, CategoryId = @categoryId, VendorId = @vendorId";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            SqlParameter priceParam = new SqlParameter("@price", price);
            command.Parameters.Add(priceParam);
            SqlParameter categoryIdParam = new SqlParameter("@categoryId", categoryId);
            command.Parameters.Add(categoryIdParam);
            SqlParameter vendorIdParam = new SqlParameter("@vendorId", vendorId);
            command.Parameters.Add(vendorIdParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
