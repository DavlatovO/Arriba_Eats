using System;

namespace Arriba_Eats
{

    class Restaurant_Register
    {
        private static List<Restaurant> restaurants = new List<Restaurant>();

        // Only allowed way to add restaurants
        public static void Register(Restaurant restaurant)
        {
            if (restaurant != null)
                restaurants.Add(restaurant);
        }

       public static List<Restaurant> GetAllRestaurants()
        {
            return new List<Restaurant>(restaurants);
        }


    }



}