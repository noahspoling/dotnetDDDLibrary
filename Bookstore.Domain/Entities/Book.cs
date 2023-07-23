//Book.cs

using Bookstore.Domain.ValueObjects;

namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public int Id {get; set; }
        public Title Title {get; set;}
        public Author Author {get; set;}
        public Genre Genre {get; set;}
        public string ISBN {get; set;}

        public Book() {

        }
        public Book(Title title, Genre genre, string isbn) {
            Title = title;
            Genre = genre;
            ISBN = isbn;
        }
        public Book(int id, Title title, Genre genre, string isbn) {
            Id = id;
            Title = title;
            Genre = genre;
            ISBN = isbn;
        }
        public Book(Title title, Author author, Genre genre, string isbn) {
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = isbn;

        }
        public Book(int id, Title title, Author author, Genre genre, string isbn) {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
            ISBN = isbn;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}