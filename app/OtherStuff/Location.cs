using System;
namespace Arriba_Eats
{
    public class Location
    {
        public double X{get; set;}
        public double Y{get; set;}

        public Location(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double DistanceTo(Location other)
        {
            double dx = this.X - other.X;
            double dy = this.Y - other.Y;
            return Math.Abs(dx) + Math.Abs(dy);
        }


    }



}