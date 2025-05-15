using System;
using System.Security.Cryptography.X509Certificates;
namespace Arriba_Eats
{
    class SortMenu
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
                int ALLRESTAURANTSPLUS_INDEX = allRestaurant.Count +1;
                var sortedByDistance = allRestaurant.OrderBy(r => r.Restaurant_Location.DistanceTo(customer.AddressCoordinates)).ToList();
                


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
                            Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                            foreach (var restaurant in sortedByName)
                            {
                                i++;
                                double distance = restaurant.Restaurant_Location.DistanceTo(customer.AddressCoordinates);
                                Console.WriteLine($"{i}: {restaurant.Restaurant_Name,-20} {distance,6:F2} {restaurant.CuisineStyle,-10} {restaurant.Restaurant_Rating:F1}");
                                Console.WriteLine();
                            }
                            Console.WriteLine($"{ALLRESTAURANTSPLUS_INDEX}: Return to the previous menu");
                            Console.WriteLine($"Please enter a choice between 1 and {ALLRESTAURANTSPLUS_INDEX}:");
                            int number;
                            if (!int.TryParse(Console.ReadLine(), out number))
                            {
                                Console.WriteLine("Please enter a valid number.");
                                continue;
                            }
                            if ((number > 0) && (number < ALLRESTAURANTSPLUS_INDEX))
                                {
                                    OrderingMenu.Order(customer, sortedByName[number-1]);
                                }
                            else if (number == ALLRESTAURANTSPLUS_INDEX)
                                {
                                    return;
                                }
                            else { Console.WriteLine("Invalid choice."); }
                                break;
                        
                        case DISTANCE_INDEX:
                           
                            int b = 0;
                            Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                            foreach (var restaurant in sortedByDistance)
                            {
                                b++;
                                double distance = restaurant.Restaurant_Location.DistanceTo(customer.AddressCoordinates);
                                Console.WriteLine($"{b}: {restaurant.Restaurant_Name,-20} {distance,6:F2} {restaurant.CuisineStyle,-11} {restaurant.Restaurant_Rating:F1}");
                                Console.WriteLine();
                            }
                            Console.WriteLine($"{ALLRESTAURANTSPLUS_INDEX}: Return to the previous menu");
                            Console.WriteLine($"Please enter a choice between 1 and {ALLRESTAURANTSPLUS_INDEX}:");
                            int number2;
                            if (!int.TryParse(Console.ReadLine(), out number2))
                            {
                                Console.WriteLine("Please enter a valid number.");
                                continue;
                            }
                            if ((number2 > 0) && (number2 < ALLRESTAURANTSPLUS_INDEX))
                            {
                                OrderingMenu.Order(customer, sortedByDistance[number2 - 1]);
                            }
                            else if (number2 == ALLRESTAURANTSPLUS_INDEX)
                            {
                                return;
                            }
                            else { Console.WriteLine("Invalid choice."); }
                            break;
                            
                        case STYLE_INDEX:
                            var sortedByCuisine = allRestaurant.OrderBy(r => r.CuisineStyle.ToString()).ToList();
                            int a = 0;
                            Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                            foreach (var restaurant in sortedByCuisine)
                            {
                                a++;
                                double distance = restaurant.Restaurant_Location.DistanceTo(customer.AddressCoordinates);
                                Console.WriteLine($"{a}: {restaurant.Restaurant_Name,-20} {distance,6:F2} {restaurant.CuisineStyle,-10} {restaurant.Restaurant_Rating:F1}");
                                Console.WriteLine();
                            }
                            Console.WriteLine($"{ALLRESTAURANTSPLUS_INDEX}: Return to the previous menu");
                            Console.WriteLine($"Please enter a choice between 1 and {ALLRESTAURANTSPLUS_INDEX}:");
                            int number3;
                            if (!int.TryParse(Console.ReadLine(), out number3))
                            {
                                Console.WriteLine("Please enter a valid number.");
                                continue;
                            }
                            if ((number3 > 0) && (number3 < ALLRESTAURANTSPLUS_INDEX))
                            {
                                OrderingMenu.OrderMenu(customer, sortedByCuisine[number3 - 1]);
                            }
                            else if (number3 == ALLRESTAURANTSPLUS_INDEX)
                            {
                                return;
                            }
                            else { Console.WriteLine("Invalid choice."); }
                            break;

                            break;
                        case RATING_INDEX:
                            //var sortedByRating = allRestaurant.OrderByDescending(r => r.Restaurant_Rating).ToList();
                            break;
                        case BACK_INDEX:
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