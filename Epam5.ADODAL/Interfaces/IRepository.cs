using System;
using System.Collections.Generic;
using System.Text;

namespace Epam5.ADODAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
