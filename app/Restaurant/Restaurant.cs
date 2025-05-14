using System;
namespace Arriba_Eats
{

    public class Restaurant
    {
        private string name;
        private Location location;
        private CuisineType cuisineStyle;
        private double rating;
        public List<MenuItem> Menu { get; private set; }

        public Restaurant(string name, Location location, CuisineType cuisineStyle, double rating)
        {
            this.name = name;
            this.location = location;
            this.cuisineStyle = cuisineStyle;
            this.rating = rating;
            Menu = new List<MenuItem>();

        }

        public string Restaurant_Name
        {
            get { return name; } 
            set { name = value; }
        }

        public double Restaurant_Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    
        public CuisineType CuisineStyle
        {
            get { return cuisineStyle; }
            set { cuisineStyle = value; }
        }

        public Location Restaurant_Location
        {
            get{ return location; }
            set { location = value; }
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