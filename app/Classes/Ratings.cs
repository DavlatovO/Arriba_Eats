using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents a rating given by a customer to a restaurant, including a score and optional comment.
    /// </summary>
    class Rating
    {
        private Customer customer_rated;
        private double score;
        private string comment;
        private Restaurant forThisRestaurant;

        /// <summary>
        /// Initializes a new instance of the <see cref="Rating"/> class.
        /// </summary>
        /// <param name="customer">The customer who gave the rating.</param>
        /// <param name="rating">The numerical score given.</param>
        /// <param name="comment">An optional comment associated with the rating.</param>
        /// <param name="forthisrestaurant">The restaurant being rated.</param>
        public Rating(Customer customer, double rating, string comment, Restaurant forthisrestaurant)
        {
            this.customer_rated = customer;
            this.score = rating;
            this.comment = comment;
            forThisRestaurant = forthisrestaurant;
        }

        /// <summary>
        /// Gets or sets the numeric score of the rating.
        /// </summary>
        public double Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// Gets the optional comment left with the rating.
        /// </summary>
        public string Comment
        {
            get { return comment; }
        }

        /// <summary>
        /// Gets the customer who submitted the rating.
        /// </summary>
        public Customer Customer
        {
            get { return customer_rated; }
        }

        /// <summary>
        /// Gets the restaurant that the rating is associated with.
        /// </summary>
        public Restaurant forthisrestaurant
        {
            get { return forThisRestaurant; }
        }
    }
}
