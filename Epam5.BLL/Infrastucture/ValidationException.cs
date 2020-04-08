using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.BLL.Infrastucture
{
    class ValidationException : Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
