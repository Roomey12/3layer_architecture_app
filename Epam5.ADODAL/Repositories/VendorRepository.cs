using Epam5.ADODAL.ADO;
using Epam5.ADODAL.Entities;
using Epam5.ADODAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Epam5.ADODAL.Repositories
{
    class VendorRepository : Database, IRepository<Vendor>
    {
        public void Delete(Vendor vendor)
        {
            OpenConnection();
            string name = vendor.VendorName;
            string city = vendor.VendorCity;
            string sqlExpression = "DELETE FROM Vendors WHERE VendorName = @name AND VendorCity = @city";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            SqlParameter cityParam = new SqlParameter("@city", city);
            command.Parameters.Add(cityParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public IEnumerable<Vendor> GetAll()
        {
            OpenConnection();
            List<Vendor> vendors = new List<Vendor>();
            string sqlExpression = "Select * From Vendors";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    vendors.Add(new Vendor()
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

        public Vendor GetById(int id)
        {
            OpenConnection();
            string sqlExpression = "Select * From Vendors Where Id = @id";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();
            Vendor vendor = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    vendor = new Vendor()
                    {
                        Id = (int)reader["Id"],
                        VendorName = (string)reader["VendorName"],
                        VendorCity = (string)reader["VendorCity"]
                    };
                }
            }
            reader.Close();
            CloseConnection();
            return vendor;
        }

        public void Insert(Vendor vendor)
        {
            OpenConnection();
            string name = vendor.VendorName;
            string city = vendor.VendorCity;
            string sqlExpression = "INSERT INTO Vendors (VendorName, VendorCity) VALUES (@name, @city)";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            SqlParameter cityParam = new SqlParameter("@city", city);
            command.Parameters.Add(cityParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Update(Vendor vendor)
        {
            OpenConnection();
            string name = vendor.VendorName;
            string city = vendor.VendorCity;
            string sqlExpression = "Update Vendors SET VendorName = @name, VendorCity = @city";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            SqlParameter cityParam = new SqlParameter("@city", city);
            command.Parameters.Add(cityParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}

