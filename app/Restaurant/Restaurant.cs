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
            get{ return location; }
            set { location = value; }
        }

        //public void Restaurant_Rating
        //{
        //    var AllOrders = 
        //}
        
    
    
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