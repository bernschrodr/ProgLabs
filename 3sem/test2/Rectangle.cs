namespace test2
{
    public class Rectangle : IFigure
    {
        private Vector2D TopLeft { get; set; }
        private Vector2D TopRight { get; set; }
        private Vector2D BottomRight { get; set; }
        private Vector2D BottomLeft { get; set; }

        public double Width => Vector2D.GetDistance(TopLeft, TopRight);
        public double Height => Vector2D.GetDistance(TopLeft, BottomLeft);

        public Rectangle(Vector2D topLeft, Vector2D topRight, Vector2D bottomRight, Vector2D bottomLeft)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomRight = bottomRight;
            BottomLeft = bottomLeft;
        }

        public double GetSquare() => Width * Height;

        public double GetPerimeter() => Width * 2 + Height * 2;

        public IFigure MoveFigure(Vector2D moveCoordinates)
        {
            TopLeft += moveCoordinates;
            TopRight += moveCoordinates;
            BottomRight += moveCoordinates;
            BottomLeft += moveCoordinates;

            return this;
        }

        public override string ToString() =>
            $"A:({TopLeft.X},{TopLeft.Y}) B:({TopRight.X},{TopRight.Y}) C:({BottomLeft.X},{BottomLeft.Y}) D:({BottomRight.X},{BottomRight.Y}) " 
            + $"Perimeter:({GetPerimeter()}) Square:({GetSquare()})";
    }
}