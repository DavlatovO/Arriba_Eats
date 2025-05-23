using System;

namespace Arriba_Eats
{
    /// <summary>
    /// Represents a 2D location using X and Y coordinates.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// X-coordinate of the location.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Y-coordinate of the location.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the Location class with specified coordinates.
        /// </summary>
        /// <param name="X">The X-coordinate.</param>
        /// <param name="Y">The Y-coordinate.</param>
        public Location(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Calculates the Manhattan distance (absolute distance) to another Location.
        /// </summary>
        /// <param name="other">The other location to calculate the distance to.</param>
        /// <returns>The Manhattan distance between the two locations.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the other location is null.</exception>
        public double DistanceTo(Location other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Target location cannot be null.");
            }

            double dx = this.X - other.X;
            double dy = this.Y - other.Y;
            return Math.Abs(dx) + Math.Abs(dy);
        }
    }
}
