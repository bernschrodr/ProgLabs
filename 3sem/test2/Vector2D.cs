using System;
namespace test2
{
    public class Vector2D
    {
        public double X { get;}
        public double Y { get;}

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        static public double GetDistance(Vector2D firstPoint,Vector2D secondPoint)
        {
            double x1 = firstPoint.X;
            double y1 = firstPoint.Y;
            double x2 = secondPoint.X;
            double y2 = secondPoint.Y;
            
            double hypotenuse = Math.Sqrt(Math.Pow(Math.Abs(x2) + Math.Abs(x1), 2) + Math.Pow(Math.Abs(y2) + Math.Abs(y1), 2));
            return hypotenuse;
        }
        
        public static Vector2D operator + (Vector2D firstTerm,Vector2D secondTerm)
        {
            return new Vector2D(firstTerm.X + secondTerm.X,firstTerm.Y + secondTerm.Y);
        }
        
    }
}