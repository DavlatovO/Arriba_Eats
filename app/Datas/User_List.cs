using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Provides static methods to register and retrieve users in the application.
    /// </summary>
    class Save_User
    {
        /// <summary>
        /// Stores all registered users in memory.
        /// </summary>
        private static List<User> users = new List<User>();

        /// <summary>
        /// Registers a new user by adding them to the user list.
        /// </summary>
        /// <param name="user">The user to register. Must not be null.</param>
        // Only allowed way to add users
        public static void Register(User user)
        {
            if (user != null)
                users.Add(user);
        }

        /// <summary>
        /// Retrieves a copy of the list of all registered users.
        /// </summary>
        /// <returns>A new list containing all users.</returns>
        public static List<User> GetAllUsers()
        {
            // Return a new list to prevent external modification of the internal list
            return new List<User>(users);
        }
    }
}