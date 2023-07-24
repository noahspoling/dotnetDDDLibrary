using System.Collections.Generic;
using System.Linq;
using Bookstore.Domain.Entities;
using Bookstore.Domain.ValueObjects;
using Bookstore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookstoreContext _context;

        private readonly List<Author> _authors;
        private int nextId = 0;

        public AuthorRepository(BookstoreContext context)
        {
            _context = context;
            /*
            _authors = new List<Author>
            {
                new Author( 1, new FirstName("FirstName1"), new LastName("Lastname1")),
                new Author( 2, new FirstName("FirstName2"), new LastName("Lastname2")),
            };
            this.nextId = _authors.Count + 1;
            */
        }

        public Author GetById(int id)
        {
            return _context.Authors.Find(id);
            //return _authors.Find(author => author.Id == id);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.ToList();
            //return _authors;
        }

        public Author Add(Author author)
        {
            try
            {
                _context.Authors.Add(author);
                _context.SaveChanges();
                return author;

                /*
                _authors.Add(author);
                author.Id = this.nextId;
                this.nextId++;
                return author;
                */
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public void Update(Author author)
        {
            var existingAuthor = _context.Authors.Find(author.Id);
            if (existingAuthor != null)
            {
                _context.Entry(existingAuthor).CurrentValues.SetValues(author);
                _context.SaveChanges();
            }
            /*
            int index = _authors.FindIndex(a => a.Id == author.Id);
            if (index >= 0)
            {
                _authors[index] = author;
            }
            */
        }

        public void Delete(int id)
        {
            var authorToRemove = _context.Authors.Find(id);
            if (authorToRemove != null)
            {
                _context.Authors.Remove(authorToRemove);
                _context.SaveChanges();
            }
            /*
            Author authorToRemove = _authors.Find(author => author.Id == id);
            if (authorToRemove != null)
            {
                _authors.Remove(authorToRemove);
            }
            */
        }
    }
}