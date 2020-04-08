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
    class CategoryRepository : IRepository<Category>
    {
        private ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return _context.Categories.Where(predicate).ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.Find(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }
    }
}
