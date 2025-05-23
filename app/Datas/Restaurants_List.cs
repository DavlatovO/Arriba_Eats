using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Provides static methods to register and retrieve restaurants in the application.
    /// </summary>
    class Restaurant_Register
    {
        /// <summary>
        /// Stores all registered restaurants in memory.
        /// </summary>
        private static List<Restaurant> restaurants = new List<Restaurant>();

        /// <summary>
        /// Registers a new restaurant by adding it to the restaurant list.
        /// </summary>
        /// <param name="restaurant">The restaurant to register. Must not be null.</param>
        // Only allowed way to add restaurants
        public static void Register(Restaurant restaurant)
        {               
            if (restaurant != null)
                restaurants.Add(restaurant);
        }

        /// <summary>
        /// Retrieves a copy of the list of all registered restaurants.
        /// </summary>
        /// <returns>A new list containing all restaurants.</returns>
        public static List<Restaurant> GetAllRestaurants()
        {
            // Return a new list to prevent external modification of the internal list
            return new List<Restaurant>(restaurants);
        }
    }
}