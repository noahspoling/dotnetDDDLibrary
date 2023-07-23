//FirstName.cs

namespace Bookstore.Domain.ValueObjects
{
    public class FirstName
    {
        public string Name;
        public FirstName(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            FirstName otherFirstName = (FirstName)obj;
            return Name == otherFirstName.Name;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}