// Bookstore.API/Controllers/BooksController.cs

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Services;
using Bookstore.Domain.Entities;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        // GET api/books/5
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        // PUT api/books/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            book.Id = id;
            _bookService.UpdateBook(book);
            return NoContent();
        }

        // DELETE api/books/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingBook = _bookService.GetBookById(id);
            if (existingBook == null)
            {
                return NotFound();
            }

            _bookService.DeleteBook(id);
            return NoContent();
        }
    }
}
