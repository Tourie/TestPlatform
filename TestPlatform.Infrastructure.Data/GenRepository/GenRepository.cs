using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Domain.Interfaces;

namespace TestPlatform.Infrastructure.Data.Repositories
{
    public class GenRepository<T> : IRepository<T> where T: class
    {
        private DbContext _db;
        private DbSet<T> _set;
        private bool disposed = false;
        public GenRepository(DbContext db)
        {
            this._db = db;
            this._set = db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _set.AsNoTracking<T>();
        }
        public void Create(T item)
        {
            _set.Add(item);
            this.Save();
        }

        public void Delete(int id)
        {
            var item = _set.Find(id);
            if (item != null)
            {
                _set.Remove(item);
                this.Save();
            }
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this._db.Dispose();
                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public T GetItem(int id)
        {
            T item = _set.Find(id);
            return item;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(T item)
        {
            _db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.Save();
        }
    }
}
