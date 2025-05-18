using System;

namespace Arriba_Eats
{

    class Rating_List
    {
        private static List<Rating> ratings = new List<Rating>();

        // Only allowed way to add restaurants
        public static void Register(Rating rating)
        {
            if (rating != null)
                ratings.Add(rating);
        }

        public static List<Rating> GetAllRatings()
        {
             return new List<Rating>(ratings);
        }
        public static List<Rating> GetRealRatings()
        {
            return ratings;
        }


    }



}