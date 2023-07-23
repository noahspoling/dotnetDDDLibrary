// Bookstore.Application.Interfaces/IBookService.cs

using System.Collections.Generic;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Interfaces
{
    public interface IBookService
    {
        Book GetBookById(int id);
        IEnumerable<Book> GetAllBooks();
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int id);
    }
}
