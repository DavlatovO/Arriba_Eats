using System;
namespace Arriba_Eats
{

    public class Restaurant
    {
        private string name;
        private Location location;
        private CuisineType cuisineStyle;
        private Client owner;

        public List<MenuItem> Menu { get; private set; }

        public Restaurant(string name, Location location, CuisineType cuisineStyle, Client owner)
        {
            this.name = name;
            this.location = location;
            this.cuisineStyle = cuisineStyle;
            this.owner = owner;
            Menu = new List<MenuItem>();

        }



        public Client Owner
        {
            get { return owner; }
        }

        public string Restaurant_Name
        {
            get { return name; }
            set { name = value; }
        }

        public CuisineType CuisineStyle
        {
            get { return cuisineStyle; }
            set { cuisineStyle = value; }
        }

        public Location Restaurant_Location
        {
            get { return location; }
            set { location = value; }
        }

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

        internal List<Rating> GetAllRatings()
        {
            var AllOrders = Order_List.GetAllOrders();
            var ratings = AllOrders.Where(order => order.FromRestaurant.Restaurant_Name == this.Restaurant_Name).Select(order => order.Ratings).ToList();
            return ratings;
        }    
    }





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