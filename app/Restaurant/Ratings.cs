using System;

namespace Arriba_Eats
{

    class Rating
    {
        private Customer customer_rated;
        private double score;
        //private string comment;


        public Rating(Customer customer, double rating)
        {
            this.customer_rated = customer;
            this.score = rating;
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
        }

       




    }

    


}