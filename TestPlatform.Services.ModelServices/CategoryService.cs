using System;
using System.Collections.Generic;
using TestPlatform.Core;
using TestPlatform.Infrastructure.Data;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.Services.ModelServices
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository)
        {
            this._repository = repository;
        }
        public void CreateCategory(Category item)
        {
            _repository.Create(item);
        }

        public void DeleteCategory(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _repository.GetItem(id);
        }

        public void Save()
        {
            _repository.Save();
        }

        public void UpdateCategory(Category item)
        {
            _repository.Update(item);
        }
    }
}
