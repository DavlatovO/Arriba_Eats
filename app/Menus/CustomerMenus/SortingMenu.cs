using System;
using System.Security.Cryptography.X509Certificates;

namespace Arriba_Eats
{
    /// <summary>
    /// Provides a menu for customers to sort and select restaurants by various criteria.
    /// </summary>
    class SortMenu
    {
        /// <summary>
        /// Displays the sorting menu and allows the customer to view and select restaurants
        /// sorted by name, distance, style, or rating.
        /// </summary>
        /// <param name="customer">The customer using the menu.</param>
        public static void Sort(Customer customer)
        {
            bool exit = false;
            while (!exit)
            {
                // Menu option constants
                const int ALPHABETIC_INDEX = 1;
                const int DISTANCE_INDEX = 2;
                const int STYLE_INDEX = 3;
                const int RATING_INDEX = 4;
                const int BACK_INDEX = 5;
                const int NUMBER_OPTIONS = 5;

                // Try to retrieve all restaurants, handle errors if any
                List<Restaurant> allRestaurant;
                try
                {
                    allRestaurant = Restaurant_Register.GetAllRestaurants();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving restaurants: {ex.Message}");
                    return;
                }

                // Used for menu navigation
                int ALLRESTAURANTSPLUS_INDEX = allRestaurant.Count + 1;

                // Pre-sort restaurants by distance for efficiency, handle errors if any
                List<Restaurant> sortedByDistance;
                try
                {
                    sortedByDistance = allRestaurant
                        .OrderBy(r => r.Restaurant_Location.DistanceTo(customer.Location))
                        .ThenBy(r => r.Restaurant_Name)
                        .ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sorting by distance: {ex.Message}");
                    return;
                }

                // Display sorting options to the user
                Console.WriteLine($"How would you like the list of restaurants ordered?");
                Console.WriteLine($"1: Sorted alphabetically by name");
                Console.WriteLine($"2: Sorted by distance");
                Console.WriteLine($"3: Sorted by style");
                Console.WriteLine($"4: Sorted by average rating");
                Console.WriteLine($"5: Return to the previous menu");
                Console.WriteLine($"Please enter a choice between 1 and 5:");

                // Read and validate user input
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                if ((choice > 0) && (choice <= NUMBER_OPTIONS))
                {
                    try
                    {
                        switch (choice)
                        {
                            // Sort alphabetically by restaurant name
                            case ALPHABETIC_INDEX:
                                var sortedByName = allRestaurant.OrderBy(r => r.Restaurant_Name).ToList();
                                int i = 0;
                                Console.WriteLine("You can order from the following restaurants:");
                                Console.WriteLine("   Restaurant Name        Loc       Dist   Style       Rating");
                                foreach (var restaurant in sortedByName)
                                {
                                    i++;
                                    double distance = 0;
                                    double rating = 0;
                                    try
                                    {
                                        distance = restaurant.Restaurant_Location.DistanceTo(customer.Location);
                                        rating = restaurant.Restaurant_Rating();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error calculating distance/rating: {ex.Message}");
                                        continue;
                                    }

                                    // Display restaurant info, show '-' if no rating
                                    if (rating == 0)
                                    {
                                        Console.WriteLine($"{i,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {"-",6:F1}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{i,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {rating,6:F1}");
                                    }
                                }

                                // Prompt for restaurant selection or return
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
                                    // Go to order menu for selected restaurant
                                    OrderingMenus.OrderMenu2(customer, sortedByName[number - 1]);
                                    exit = true;
                                }
                                else if (number == ALLRESTAURANTSPLUS_INDEX)
                                {
                                    exit = true;
                                    break;
                                }
                                else { Console.WriteLine("Invalid choice."); }
                                break;

                            // Sort by distance from customer
                            case DISTANCE_INDEX:
                                int b = 0;
                                Console.WriteLine("You can order from the following restaurants:");
                                Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                                foreach (var restaurant in sortedByDistance)
                                {
                                    b++;
                                    double distance = 0;
                                    double rating = 0;
                                    try
                                    {
                                        distance = restaurant.Restaurant_Location.DistanceTo(customer.Location);
                                        rating = restaurant.Restaurant_Rating();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error calculating distance/rating: {ex.Message}");
                                        continue;
                                    }

                                    if (rating == 0)
                                    {
                                        Console.WriteLine($"{b,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {"-",6:F1}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{b,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {rating,6:F1}");
                                    }
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
                                    OrderingMenus.OrderMenu2(customer, sortedByDistance[number2 - 1]);
                                    exit = true;
                                }
                                else if (number2 == ALLRESTAURANTSPLUS_INDEX)
                                {
                                    exit = true;
                                    break;
                                }
                                else { Console.WriteLine("Invalid choice."); }
                                break;

                            // Sort by cuisine style
                            case STYLE_INDEX:
                                var sortedByCuisine = allRestaurant.OrderBy(r => r.CuisineStyle).ThenBy(r => r.Restaurant_Name).ToList();
                                int a = 0;
                                Console.WriteLine("You can order from the following restaurants:");
                                Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                                foreach (var restaurant in sortedByCuisine)
                                {
                                    a++;
                                    double distance = 0;
                                    double rating = 0;
                                    try
                                    {
                                        distance = restaurant.Restaurant_Location.DistanceTo(customer.Location);
                                        rating = restaurant.Restaurant_Rating();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error calculating distance/rating: {ex.Message}");
                                        continue;
                                    }

                                    if (rating == 0)
                                    {
                                        Console.WriteLine($"{a,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {"-",6:F1}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{a,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {rating,6:F1}");
                                    }
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
                                    OrderingMenus.OrderMenu2(customer, sortedByCuisine[number3 - 1]);
                                    exit = true;
                                }
                                else if (number3 == ALLRESTAURANTSPLUS_INDEX)
                                {
                                    exit = true;
                                    break;
                                }
                                else { Console.WriteLine("Invalid choice."); }
                                break;

                            // Sort by average restaurant rating
                            case RATING_INDEX:
                                var sortedByRating = Restaurant_Register.GetAllRestaurants()
                                    .OrderByDescending(r => r.Restaurant_Rating())
                                    .ThenBy(r => r.Restaurant_Name).ToList();
                                int c = 0;
                                Console.WriteLine("You can order from the following restaurants:");
                                Console.WriteLine("   Restaurant Name       Loc    Dist  Style       Rating");
                                foreach (var restaurant in sortedByRating)
                                {
                                    c++;
                                    double distance = 0;
                                    double rating = 0;
                                    try
                                    {
                                        distance = restaurant.Restaurant_Location.DistanceTo(customer.Location);
                                        rating = restaurant.Restaurant_Rating();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error calculating distance/rating: {ex.Message}");
                                        continue;
                                    }

                                    if (rating == 0)
                                    {
                                        Console.WriteLine($"{c,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {"-",6:F1}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{c,2}: {restaurant.Restaurant_Name,-20} {restaurant.Restaurant_Location.X,1},{restaurant.Restaurant_Location.Y,1}  {distance,6}  {restaurant.CuisineStyle,-10} {rating,6:F1}");
                                    }
                                }

                                Console.WriteLine($"{ALLRESTAURANTSPLUS_INDEX}: Return to the previous menu");
                                Console.WriteLine($"Please enter a choice between 1 and {ALLRESTAURANTSPLUS_INDEX}:");
                                int number4;
                                if (!int.TryParse(Console.ReadLine(), out number4))
                                {
                                    Console.WriteLine("Please enter a valid number.");
                                    continue;
                                }
                                if ((number4 > 0) && (number4 < ALLRESTAURANTSPLUS_INDEX))
                                {
                                    OrderingMenus.OrderMenu2(customer, sortedByRating[number4 - 1]);
                                    exit = true;
                                }
                                else if (number4 == ALLRESTAURANTSPLUS_INDEX)
                                {
                                    exit = true;
                                    break;
                                }
                                else { Console.WriteLine("Invalid choice."); }
                                break;

                            // Return to previous menu
                            case BACK_INDEX:
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("Invalid choice.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu choice.");
                }
            }
        }
    }
}
