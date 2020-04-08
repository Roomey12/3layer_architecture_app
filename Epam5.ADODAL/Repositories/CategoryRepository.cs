using Epam5.ADODAL.ADO;
using Epam5.ADODAL.Entities;
using Epam5.ADODAL.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.ADODAL.Repositories
{
    class CategoryRepository : Database, IRepository<Category>
    {
        public void Delete(Category category)
        {
            OpenConnection();
            string name = category.CategoryName;
            string sqlExpression = "DELETE FROM Categories WHERE CategoryName = @name";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public IEnumerable<Category> GetAll()
        {
            OpenConnection();
            List<Category> categories = new List<Category>();
            string sqlExpression = "Select * From Categories";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categories.Add(new Category()
                    {
                        Id = (int)reader["Id"],
                        CategoryName = (string)reader["CategoryName"],
                    });
                }
            }
            reader.Close();
            CloseConnection();
            return categories;
        }

        public Category GetById(int id)
        {
            OpenConnection();
            string sqlExpression = "Select * From Categories Where Id = @id";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter idParam = new SqlParameter("@id", id);
            command.Parameters.Add(idParam);
            SqlDataReader reader = command.ExecuteReader();
            Category category = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    category = new Category()
                    {
                        Id = (int)reader["Id"],
                        CategoryName = (string)reader["CategoryName"]
                    };
                }
            }
            reader.Close();
            CloseConnection();
            return category;
        }

        public void Insert(Category category)
        {
            OpenConnection();
            string name = category.CategoryName;
            string sqlExpression = "INSERT INTO Categories (CategoryName) VALUES (@name)";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void Update(Category category)
        {
            OpenConnection();
            string name = category.CategoryName;
            string sqlExpression = "Update Categories SET CategoryName = @name";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlParameter nameParam = new SqlParameter("@name", name);
            command.Parameters.Add(nameParam);
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
