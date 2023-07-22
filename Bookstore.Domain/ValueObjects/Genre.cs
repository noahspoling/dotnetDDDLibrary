//Genre.cs

namespace Bookstore.Domain.ValueObjects
{
    public class Genre
    {
        public string Name;
        public Genre(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Genre otherGenre = (Genre)obj;
            return Name == otherGenre.Name;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}