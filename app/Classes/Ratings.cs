using System;

namespace Arriba_Eats
{

    class Rating
    {
        private Customer customer_rated;
        private double score;
        private string comment;
        private Restaurant forThisRestaurant;


        public Rating(Customer customer, double rating, string comment, Restaurant forthisrestaurant)
        {
            this.customer_rated = customer;
            this.score = rating;
            this.comment = comment;
            forThisRestaurant = forthisrestaurant;
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
        }
        public string Comment
        { get { return comment; } }

        public Customer Customer
        { get { return customer_rated; } }

        public Restaurant forthisrestaurant
        {
            get { return forThisRestaurant; }
        }
       




    }

    


}