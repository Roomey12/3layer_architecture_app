using Epam5.EFDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.EFDAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Vendor> Vendors { get; }
        void Save();
    }
}
