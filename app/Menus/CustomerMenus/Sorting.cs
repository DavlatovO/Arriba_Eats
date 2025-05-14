using System;
namespace Arriba_Eats
{
    class Sorting
    {



        public static void Sort(Customer customer)
        {

            while (true)
            {
                const int ALPHABETIC_INDEX = 1;
                const int DISTANCE_INDEX = 2;
                const int STYLE_INDEX = 3;
                const int RATING_INDEX = 4;
                const int BACK_INDEX = 5;
                const int NUMBER_OPTIONS = 5;
                List<Restaurant> allRestaurant = Restaurant_Register.GetAllRestaurants();

                Console.WriteLine();    
                Console.WriteLine($"1: How would you like the list of restaurants ordered?");
                Console.WriteLine($"1: Sorted alphabetically by name");
                Console.WriteLine($"2: Sorted by distance");
                Console.WriteLine($"3: Sorted by style");
                Console.WriteLine($"4: Sorted by average rating");
                Console.WriteLine($"5: Return to the previous menu");
                Console.WriteLine($"Please enter a choice between 1 and 5:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }
                if ((choice > 0) && (choice <= NUMBER_OPTIONS))
                {
                    switch (choice)
                    {
                        case ALPHABETIC_INDEX:
                            var sortedByName = allRestaurant.OrderBy(r => r.Restaurant_Name).ToList();
                            int i = 0;
                            foreach(var restaurant in sortedByName)
                            {
                                i++;
                                Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                                Console.WriteLine($"{i}: {restaurant.Restaurant_Name,-33}  {restaurant.CuisineStyle,-10} {restaurant.Restaurant_Rating:F1}");
                                Console.WriteLine();
                            }
                            break;
                        case DISTANCE_INDEX:

                            break;
                        case STYLE_INDEX:
                            var sortedByCuisine = allRestaurant.OrderBy(r => r.CuisineStyle.ToString()).ToList();
                            int a = 0;
                            foreach (var restaurant in sortedByCuisine)
                            {
                                a++;
                                Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                                Console.WriteLine($"{a}: {restaurant.Restaurant_Name,-33}  {restaurant.CuisineStyle,-10} {restaurant.Restaurant_Rating:F1}");
                                Console.WriteLine();
                            }

                            break;
                        case RATING_INDEX:
                            //var sortedByRating = allRestaurant.OrderByDescending(r => r.Restaurant_Rating).ToList();
                            break;
                        case BACK_INDEX:
                            return;
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;


                    }
                }
            }
        }
    }
}