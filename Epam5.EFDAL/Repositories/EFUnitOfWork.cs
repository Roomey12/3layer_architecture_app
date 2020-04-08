using System;
using System.Collections.Generic;
using System.Text;
using Epam5.EFDAL.EF;
using Epam5.EFDAL.Entities;
using Epam5.EFDAL.Interfaces;

namespace Epam5.EFDAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private ProductRepository productRepository;
        private VendorRepository vendorRepository;
        private CategoryRepository categoryRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(_context);
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
                    categoryRepository = new CategoryRepository(_context);
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
                    vendorRepository = new VendorRepository(_context);
                }

                return vendorRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
