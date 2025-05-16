using System;

namespace Arriba_Eats
{

    class Rating
    {
        private Customer customer_rated;
        private double score;
        private string comment;


        public Rating(Customer customer, double rating, string commment)
        {
            this.customer_rated = customer;
            this.score = rating;
            this.comment = commment;
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

       




    }

    


}