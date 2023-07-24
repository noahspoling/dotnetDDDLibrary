//Author.cs

using Bookstore.Domain.ValueObjects;

namespace Bookstore.Domain.Entities
{
    public class Author
    {
        public int Id {get; set;}
        public FirstName FirstName {get; set;}
        public LastName LastName {get; set;}

        public Author()
        {

        }

        public Author(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Author(int id, FirstName firstName, LastName lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}