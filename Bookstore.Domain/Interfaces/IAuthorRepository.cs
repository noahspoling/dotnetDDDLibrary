using System.Collections.Generic;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        //TODO: search interface and implementation
        Author GetById(int id);
        IEnumerable<Author> GetAll();
        Author Add(Author book);
        void Update(Author book);
        void Delete(int id);
    }
}