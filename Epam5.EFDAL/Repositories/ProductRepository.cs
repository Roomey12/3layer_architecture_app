using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epam5.EFDAL.EF;
using Epam5.EFDAL.Entities;
using Epam5.EFDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Epam5.EFDAL.Repositories
{
    class ProductRepository : IRepository<Product>
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return _context.Products
                .Include(o=>o.Category)
                .Include(o=>o.Vendor)
                .Where(predicate).ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products
                .Include(o => o.Category)
                .Include(o => o.Vendor).ToList();
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }
    }
}
