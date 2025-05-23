using System;
namespace Arriba_Eats
{
    /// <summary>
    /// Restaurant class creates and manages restaurant objects with a name, location, cuisine style, and owner.
    /// </summary>
    public class Restaurant
    {
        /// <summary>
        /// Restaurant name.
        /// </summary>
        private string name;
        /// <summary>
        /// Restaurant location.
        /// </summary>
        private Location location;
        /// <summary>
        /// Restaurant cuisine style.
        /// </summary>
        private CuisineType cuisineStyle;
        /// <summary>
        /// Restaurant owner.
        /// </summary>
        private Client owner;
        /// <summary>
        /// List of menu items for the restaurant.
        /// </summary>
        public List<MenuItem> Menu { get; private set; }

        //Constructorer for Restaurant class
        public Restaurant(string name, Location location, CuisineType cuisineStyle, Client owner)
        {
            this.name = name;
            this.location = location;
            this.cuisineStyle = cuisineStyle;
            this.owner = owner;
            Menu = new List<MenuItem>();

        }


        /// <summary>
        /// Gets the client that owns the restaurant.
        /// </summary>
        public Client Owner
        {
            get { return owner; }
        }
        /// <summary>
        /// Restaurant name with get and set.
        /// </summary>
        public string Restaurant_Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// Restaurant cuisine style with get and set.
        /// </summary>
        public CuisineType CuisineStyle
        {
            get { return cuisineStyle; }
            set { cuisineStyle = value; }
        }
        /// <summary>
        /// Restaurant location with get and set.
        /// </summary>
        public Location Restaurant_Location
        {
            get { return location; }
            set { location = value; }
        }
        /// <summary>
        /// Calculates the average rating for the current restaurant based on all available ratings.
        /// </summary>
        /// <remarks>If there are no ratings for the restaurant, the method returns <see
        /// langword="0.0"/>.</remarks>
        /// <returns>The average rating as a <see cref="double"/> for the current restaurant. Returns <see langword="0.0"/> if no
        /// ratings are available.</returns>
        public double Restaurant_Rating()
        {
                var AllRatings = Rating_List.GetAllRatings();
                var myRatings = AllRatings.Where(rating => rating.forthisrestaurant.Restaurant_Name == this.Restaurant_Name);

                //If there are no orders return 0
                if (!myRatings.Any())
                    return 0.0;

                //Calculate and return average rating
                return myRatings.Average(rating => rating.Score);
        }

        /// <summary>
        /// The method returns a list of all ratings for the restaurant.
        /// </summary>
        /// <returns></returns>
        internal List<Rating> GetAllRatings()
        {
            var AllOrders = Order_List.GetAllOrders();
            var ratings = AllOrders.Where(order => order.FromRestaurant.Restaurant_Name == this.Restaurant_Name).Select(order => order.Ratings).ToList();
            return ratings;
        }    
    }
    /// <summary>
    /// The enum CuisineType defines the different types of cuisine available for restaurants.
    /// </summary>
    public enum CuisineType
    {
        Italian,
        French,
        Chinese,
        Japanese,
        American,
        Australian
    }
}