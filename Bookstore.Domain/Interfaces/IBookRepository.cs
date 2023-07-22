using System.Collections.Generic;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository
    {
        //TODO: search interface and implementation
        Book GetById(int id);
        IEnumerable<Book> GetAll();
        void Add(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}