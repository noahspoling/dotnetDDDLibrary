//BookDTO.cs

/*
    Used for structuring book entitiy in the controller to do CRUD operations on Book objects so it can convert things like strings to the value objects
*/

namespace Bookstore.Domain.Models
{
    public class BookDTO
    {
        //TODO: add private access to DTO objects
        public int? Id {get; set;}
        public string? Title {get; set;}
        public int? AuthorId {get; set;}
        public string? Genre {get; set;}
        public string? ISBN {get; set;}

        public BookDTO()
        {

        }

        //Posting new book DTO
        public BookDTO(string title, int authorId, string genre, string isbn)
        {
            Title = title;
            AuthorId = authorId;
            Genre = genre;
            ISBN = isbn;
        }
        
        //Posting new authorless book DTO
        public BookDTO(string title, string genre, string isbn)
        {
            Title = title;
            Genre = genre;
            ISBN = isbn;
        }

        //Querring existing authorless book 
        public BookDTO(int id, string title, string genre, string isbn)
        {
            Id = id;
            Title = title;
            Genre = genre;
            ISBN = isbn;
        }

        //Querring existing book 
        public BookDTO(int id, string title, int authorId, string genre, string isbn)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Genre = genre;
            ISBN = isbn;
        }
    }
}