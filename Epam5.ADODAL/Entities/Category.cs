using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.ADODAL.Entities
{
    public class Category
    {
        public static List<Category> ExistingCategories = new List<Category>();
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public Category(string categoryName)
        {
            CategoryName = categoryName;
            ExistingCategories.Add(this);
        }
        public Category()
        {

        }
    }
}
