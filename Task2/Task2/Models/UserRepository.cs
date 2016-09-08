using System.Collections.Generic;
using System.Linq;

namespace Task2.Models
{
    public static class UserRepository
    {
        private static int currentUserId = 0;

        static UserRepository()
        {
            Users = new List<User>();
            AddUser(new User("John", "Smith"));
            AddUser(new User("Andrew", "Brown"));
        }

        public static List<User> Users { get; }

        public static void AddUser(User user)
        {
            user.Id = ++currentUserId;
            Users.Add(user);
        }

        public static void DeleteUser(int id)
        {
            User user = Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Users.Remove(user);
            }
        }

        public static void EditUser(User newUser)
        {
            User user = Users.FirstOrDefault(u => u.Id == newUser.Id);

            if (newUser != null)
            {
                user.FirstName = newUser.FirstName;
                user.LastName = newUser.LastName;
            }
        }
    }
}