using Epam5.ADODAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.ADODAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Vendor> Vendors { get; }
        void Save();
    }
}
