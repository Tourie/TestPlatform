using System;
using System.Collections.Generic;
using System.Text;

namespace TestPlatform.Infrastructure.Data
{
    public interface IRepository<T>: IDisposable
        where T: class
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetItem(int id);
        public ApplicationContext GetContext();
        void Save();
    }
}