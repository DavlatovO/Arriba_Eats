using System;

namespace Arriba_Eats
{
    class Save_User
    {
        private static List<User> users = new List<User>();

        // Only allowed way to add restaurants
        public static void Register(User user)
        {
            if (user != null)
                users.Add(user);
        }

        public static List<User> GetAllUsers()
        {
            return new List<User>(users);
        }
    }






}