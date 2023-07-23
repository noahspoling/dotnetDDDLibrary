//Author.cs

using Bookstore.Domain.ValueObjects;

namespace Bookstore.Domain.Entities
{
    public class Author
    {
        public int Id;
        public FirstName FirstName;
        public LastName LastName;

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
            FirstName = firstName;
            LastName = lastName;
        }
    }
}