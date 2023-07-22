using System.Collections.Generic;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            // Initialize the in-memory book list (for demonstration purposes)
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "dsd", Author = "Author 1", Genre = new Genre("Fiction"), ISBN = "123456789" },
                new Book { Id = 2, Title = "Book 2", Author = "Author 2", Genre = new Genre("Fantasy"), ISBN = "987654321" }
                // Add more books as needed
            };
        }

        public Book GetById(int id)
        {
            return _books.Find(book => book.Id == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public void Add(Book book)
        {
            // For a real implementation, you would interact with a database or data store here.
            _books.Add(book);
        }

        public void Update(Book book)
        {
            // For a real implementation, you would interact with a database or data store here.
            int index = _books.FindIndex(b => b.Id == book.Id);
            if (index >= 0)
            {
                _books[index] = book;
            }
        }

        public void Delete(int id)
        {
            // For a real implementation, you would interact with a database or data store here.
            Book bookToRemove = _books.Find(book => book.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }
    }
}