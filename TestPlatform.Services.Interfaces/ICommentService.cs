using System;
using System.Collections.Generic;
using System.Text;
using TestPlatform.Core;

namespace TestPlatform.Services.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments();
        Comment GetComment(int id);
        public void Create(Comment comment);
        IEnumerable<Comment> GetCommentsByTest(Test test);
        void SaveComment(Comment comment);
        void DeleteComment(int id);
    }
}
