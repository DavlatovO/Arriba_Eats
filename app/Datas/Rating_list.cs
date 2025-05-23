using System;

namespace Arriba_Eats
{
    /// <summary>
    /// The Rating_List class provides static methods to register and retrieve ratings in the application.
    /// </summary>
    class Rating_List
    {
        private static List<Rating> ratings = new List<Rating>();

        // Only allowed way to add restaurants
        public static void Register(Rating rating)
        {
            if (rating != null)
                ratings.Add(rating);
        }

        //Getting all the ratings where we do not actually need to modify the list
        // So we return a new list to prevent external modification of the internal list
        public static List<Rating> GetAllRatings()
        {
             return new List<Rating>(ratings);
        }
        // Getting the real list of ratings where we need to modify the list
        public static List<Rating> GetRealRatings()
        {
            return ratings;
        }


    }

}