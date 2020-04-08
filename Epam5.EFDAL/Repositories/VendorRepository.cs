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
    class VendorRepository : IRepository<Vendor>
    {
        private ApplicationContext _context;

        public VendorRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Create(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
        }

        public void Delete(int id)
        {
            Vendor vendor = _context.Vendors.Find(id);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
            }
        }

        public IEnumerable<Vendor> Find(Func<Vendor, bool> predicate)
        {
            return _context.Vendors.Where(predicate).ToList();
        }

        public Vendor Get(int id)
        {
            return _context.Vendors.Find(id);
        }

        public IEnumerable<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }

        public void Update(Vendor vendor)
        {
            _context.Entry(vendor).State = EntityState.Modified;
        }
    }
}
