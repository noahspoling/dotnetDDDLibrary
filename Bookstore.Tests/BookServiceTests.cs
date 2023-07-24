// Bookstore.Tests/BookServiceTests.cs

using Xunit;
using Moq;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects;
using Bookstore.Application.Services;
using System.Collections.Generic;

namespace Bookstore.Tests
{
    public class BookServiceTests
    {
        private readonly Mock<IBookRepository> _bookRepositoryMock;
        private readonly IBookService _bookService;

        public BookServiceTests()
        {
            _bookRepositoryMock = new Mock<IBookRepository>();
            _bookService = new BookService(_bookRepositoryMock.Object);
        }

        [Fact]
        public void GetBookById_WhenCalled_ReturnsBookFromRepo()
        {
            // Arrange
            var bookId = 1;
            var bookTitle = new Title("The Catcher in the Rye");
            var bookGenre = new Genre("Fiction");
            var bookIsbn = "123-456-789";

            var bookFromRepo = new Book(bookId, bookTitle, bookGenre, bookIsbn);

            _bookRepositoryMock.Setup(repo => repo.GetById(bookId)).Returns(bookFromRepo);

            // Act
            var returnedBook = _bookService.GetBookById(bookId);

            // Assert
            Assert.Equal(bookFromRepo, returnedBook);
            _bookRepositoryMock.Verify(repo => repo.GetById(bookId), Times.Once());
        }

        [Fact]
        public void GetAllBooks_WhenCalled_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Book>()
            {
                new Book(new Title("To Kill a Mockingbird"), new Genre("Fiction"), "234-567-890"),
                new Book(new Title("1984"), new Genre("Fiction"), "345-678-901"),
                new Book(new Title("The Great Gatsby"), new Genre("Fiction"), "456-789-012"),
            };

            _bookRepositoryMock.Setup(repo => repo.GetAll()).Returns(books);

            // Act
            var returnedBooks = _bookService.GetAllBooks();

            // Assert
            Assert.Equal(books, returnedBooks);
            _bookRepositoryMock.Verify(repo => repo.GetAll(), Times.Once());
        }

        [Fact]
        public void AddBook_WhenCalled_AddsBookToRepo()
        {
            // Arrange
            var book = new Book(new Title("Moby Dick"), new Genre("Fiction"), "567-890-123");

            _bookRepositoryMock.Setup(repo => repo.Add(book)).Verifiable();

            // Act
            _bookService.AddBook(book);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.Add(book), Times.Once());
        }

        [Fact]
        public void UpdateBook_WhenCalled_UpdatesBookInRepo()
        {
            // Arrange
            var book = new Book(1, new Title("Moby Dick"), new Genre("Fiction"), "567-890-123");

            _bookRepositoryMock.Setup(repo => repo.Update(book)).Verifiable();

            // Act
            _bookService.UpdateBook(book);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.Update(book), Times.Once());
        }

        [Fact]
        public void DeleteBook_WhenCalled_DeletesBookFromRepo()
        {
            // Arrange
            var bookId = 1;

            _bookRepositoryMock.Setup(repo => repo.Delete(bookId)).Verifiable();

            // Act
            _bookService.DeleteBook(bookId);

            // Assert
            _bookRepositoryMock.Verify(repo => repo.Delete(bookId), Times.Once());
        }

    }
}
