using Epam5.ADODAL.Entities;
using Epam5.ADODAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.ADODAL.Repositories
{
    public class ADOUnitOfWork : IUnitOfWork
    {
        private ProductRepository productRepository;
        private VendorRepository vendorRepository;
        private CategoryRepository categoryRepository;

        public ADOUnitOfWork()
        {
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository();
                }

                return productRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository();
                }

                return categoryRepository;
            }
        }

        public IRepository<Vendor> Vendors
        {
            get
            {
                if (vendorRepository == null)
                {
                    vendorRepository = new VendorRepository();
                }

                return vendorRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
