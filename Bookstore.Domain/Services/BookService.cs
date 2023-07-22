// Bookstore.Domain.Services

using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Domain.Services
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}