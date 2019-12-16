namespace test2
{
    public interface IFigure
    {
        double GetSquare();
        double GetPerimeter();
        IFigure MoveFigure(Vector2D coordinates);
    }
}