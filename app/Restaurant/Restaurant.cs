using System;
namespace Arriba_Eats
{

    public class Restaurant
    {
        private string name;
        private Location location;
        private CuisineType cuisineStyle;
        
        public List<MenuItem> Menu { get; private set; }
        private List<Rating> ratings;
        public Restaurant(string name, Location location, CuisineType cuisineStyle)
        {
            this.name = name;
            this.location = location;
            this.cuisineStyle = cuisineStyle;
            Menu = new List<MenuItem>();
            ratings = new List<Rating>();

        }

        public string Restaurant_Name
        {
            get { return name; } 
            set { name = value; }
        }

        internal List<Rating> Restaurant_Rating()
        {
            return ratings;
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