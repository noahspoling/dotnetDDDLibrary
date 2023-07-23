//LastName.cs

namespace Bookstore.Domain.ValueObjects
{
    public class LastName
    {
        public string Name;
        public LastName(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            LastName otherLastName = (LastName)obj;
            return Name == otherLastName.Name;
        }
        
        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}