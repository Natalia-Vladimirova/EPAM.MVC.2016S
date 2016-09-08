namespace Task2.Models
{
    public class User
    {
        public User() { }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            
            User user = obj as User;

            if (user == null)
            {
                return false;
            }

            return Id == user.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}