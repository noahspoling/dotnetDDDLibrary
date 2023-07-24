// Bookstore.Application.Interfaces/IBookService.cs

using System.Collections.Generic;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Models;
namespace Bookstore.Domain.Interfaces
{
    public interface IAuthorService
    {
        bool AuthorExists(int id);
        AuthorDTO GetAuthorById(int id);
        IEnumerable<AuthorDTO> GetAllAuthors();
        AuthorDTO AddAuthor(AuthorDTO book);
        void UpdateAuthor(int id, AuthorDTO book);
        void DeleteAuthor(int id);
    }
}
