using System;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle(new Vector2D(0,0),new Vector2D(0,10),new Vector2D(0,-10),new Vector2D(-10,-10)   );
            Console.WriteLine(rect1);
            Console.WriteLine(rect1.GetPerimeter());
            Console.WriteLine(rect1.GetSquare());
            rect1.MoveFigure(new Vector2D(12, 4));
            Console.WriteLine(rect1);
            
            
        }
    }
}