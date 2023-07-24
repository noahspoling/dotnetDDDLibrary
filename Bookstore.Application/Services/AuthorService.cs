// Bookstore.Application.Services/BookService.cs

using System.Collections.Generic;
using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;

namespace Bookstore.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public bool AuthorExists(int id) {
            var author = _authorRepository.GetById(id);
            return author != null;
        }

        public AuthorDTO GetAuthorById(int id)
        {
            var author = _authorRepository.GetById(id);
            return new AuthorDTO(
                author.Id,
                author.FirstName.Name,
                author.LastName.Name
            );
        }

        public IEnumerable<AuthorDTO> GetAllAuthors()
        {
            var authors = _authorRepository.GetAll();
            return authors.Select(a => new AuthorDTO
            {
                Id = a.Id,
                FirstName = a.FirstName.Name,
                LastName = a.LastName.Name
            }).ToList();
        }

        public AuthorDTO AddAuthor(AuthorDTO author)
        {
            Author authorEntity = new Author(
                new FirstName(author.FirstName),
                new LastName(author.LastName)
            );
            try
            {
                Author authorResp = _authorRepository.Add(authorEntity);
                return new AuthorDTO(
                    authorResp.Id,
                    authorResp.FirstName.Name,
                    authorResp.LastName.Name);
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        public void UpdateAuthor(int id, AuthorDTO author)
        {
            Author authorEntity = new Author(
                id,
                new FirstName(author.FirstName),
                new LastName(author.LastName)
            );
            _authorRepository.Update(authorEntity);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }
    }
}
