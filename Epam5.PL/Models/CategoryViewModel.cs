using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.PL.Models
{
    class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public override string ToString()
        {
            return $"{nameof(Id)}: {Id};\t{nameof(CategoryName)}: {CategoryName};";
        }
    }
}
