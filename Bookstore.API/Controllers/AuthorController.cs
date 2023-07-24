//AuthorController.cs

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Bookstore.Domain.Interfaces;
using Bookstore.Application.Services;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Models;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        // GET api/author
        [HttpGet]
        public ActionResult<IEnumerable<AuthorDTO>> GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        // GET api/author/5
        [HttpGet("{id}")]
        public ActionResult<AuthorDTO> GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // POST api/author
        [HttpPost]
        public IActionResult AddAuthor(AuthorDTO author)
        {
            var authorResp = _authorService.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = authorResp.Id }, authorResp);
        }

        // PUT api/author/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, AuthorDTO author)
        {
            var existingAuthor = _authorService.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            author.Id = id;
            _authorService.UpdateAuthor(id, author);
            return NoContent();
        }

        // DELETE api/author/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var existingAuthor = _authorService.GetAuthorById(id);
            if (existingAuthor == null)
            {
                return NotFound();
            }

            _authorService.DeleteAuthor(id);
            return NoContent();
        }
    }
}