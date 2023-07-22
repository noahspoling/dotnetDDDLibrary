//Genre.cs

namespace Bookstore.Domain.ValueObjects
{
    public class Title
    {
        public string Name;
        public Title(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Title otherGenre = (Title)obj;
            return Name == otherGenre.Name;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}