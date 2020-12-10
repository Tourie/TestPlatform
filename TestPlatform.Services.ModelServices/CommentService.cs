using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestPlatform.Core;
using TestPlatform.Infrastructure.Data;
using TestPlatform.Services.Interfaces;

namespace TestPlatform.Services.ModelServices
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _repository;
        public CommentService(IRepository<Comment> repository)
        {
            this._repository = repository;
        }
        public void DeleteComment(int id)
        {
            _repository.Delete(id);
        }

        public void Create(Comment comment)
        {
            _repository.Create(comment);
        }

        public IEnumerable<Comment> GetCommentsByTest (Test test)
        {
            return _repository.GetContext().Comments.Where(comment => comment.TestId == test.Id);
        }

        public Comment GetComment(int id)
        {
            return _repository.GetItem(id);
        }

        public IEnumerable<Comment> GetComments()
        {
            return _repository.GetAll();
        }

        public void SaveComment(Comment comment)
        {
            if (comment.Id == default)
            {
                _repository.GetContext().Entry(comment).State = EntityState.Added;
            }
            else
            {
                _repository.GetContext().Entry(comment).State = EntityState.Modified;
            }
            _repository.GetContext().SaveChanges();
        }
    }
}
