// Bookstore.Application.Services/BookService.cs

using System.Collections.Generic;
using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects;
using Bookstore.Domain.Models;
using Bookstore.Domain.Interfaces;
using Bookstore.Application.Services;

namespace Bookstore.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public bool BookExists(int id) {
            var book = _bookRepository.GetById(id);
            return book != null;
        }

        public BookDTO GetBookById(int id)
        {
            var book = _bookRepository.GetById(id);
            return new BookDTO(
                book.Id,
                book.Title.Name,
                book.Author.Id,
                book.Genre.Name,
                book.ISBN
            );
        }

        public IEnumerable<BookDTO> GetAllBooks()
        {
            var books = _bookRepository.GetAll();
            return books.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title.Name,
                AuthorId = b.Author.Id,
                Genre = b.Genre.Name,
                ISBN = b.ISBN
            }).ToList();
        }

        public void AddBook(BookDTO book)
        {
            if(!_authorService.AuthorExists((int)book.AuthorId)) {

            }
            else {
                int authorId = book.AuthorId.Value;
                var authorEntity = _authorService.GetAuthorById(authorId);
                var bookEntity = new Book(
                    new Title(book.Title),
                    new Author(authorId,
                        new FirstName(authorEntity.FirstName),
                        new LastName(authorEntity.LastName)
                    ),
                    new Genre(book.Genre),
                    book.ISBN
                );
                _bookRepository.Add(bookEntity);
            }
        }

        public void UpdateBook(int id, BookDTO book)
        {
            if(!_authorService.AuthorExists((int)book.AuthorId)) {

            }
            else {
                int authorId = book.AuthorId.Value;
                //TODO handle if null
                var authorEntity = _authorService.GetAuthorById(authorId);
                var bookEntity = new Book(
                    id,
                    new Title(book.Title),
                    new Author(authorId,
                        new FirstName(authorEntity.FirstName),
                        new LastName(authorEntity.LastName)
                    ),
                    new Genre(book.Genre),
                    book.ISBN
                );
                _bookRepository.Update(bookEntity);
            }
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
    }
}
