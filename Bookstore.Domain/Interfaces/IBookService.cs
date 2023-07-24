// Bookstore.Application.Interfaces/IBookService.cs

using System.Collections.Generic;
using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects;
using Bookstore.Domain.Models;
namespace Bookstore.Domain.Interfaces
{
    public interface IBookService
    {
        bool BookExists(int id);
        BookDTO GetBookById(int id);
        IEnumerable<BookDTO> GetAllBooks();
        void AddBook(BookDTO book);
        void UpdateBook(int id, BookDTO book);
        void DeleteBook(int id);
    }
}
