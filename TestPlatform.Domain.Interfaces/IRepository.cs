using System;
using System.Collections.Generic;
using System.Text;

namespace TestPlatform.Domain.Interfaces
{
    public interface IRepository<T>: IDisposable
        where T: class
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}