using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Domain.Core;
using TestPlatform.Domain.Interfaces;

namespace TestPlatform.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationContext db;
        private bool disposed = false;
        public CategoryRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public IEnumerable<Category> AllCategories()
        {
            return db.Categories;
        }
        public void Create(Category item)
        {
            db.Categories.Add(item);
        }

        public void Delete(int id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
            {
                db.Categories.Remove(category);
            }
        }

        public void Dispose()
        {
            if (!this.disposed)
            {
                this.db.Dispose();
                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        public Category GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            return category;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category item)
        {
            db.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}
