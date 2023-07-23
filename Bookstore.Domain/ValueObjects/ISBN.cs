//LastName.cs

namespace Bookstore.Domain.ValueObjects
{
    public class ISBN
    {
        public string Name;
        public ISBN(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            ISBN otherISBN = (ISBN)obj;
            return Name == otherISBN.Name;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}