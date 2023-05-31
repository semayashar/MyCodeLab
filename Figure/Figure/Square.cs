internal class Square : Figure
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double CalculateArea()
    {
        return side * side;
    }

    public override double CalculatePerimeter()
    {
        return 4 * side;
    }

    public override void PrintDetails()
    {
        Console.WriteLine("Square:");
        Console.WriteLine("Side: " + side.ToString("0.00") + " cm");
        Console.WriteLine("Area: " + CalculateArea().ToString("0.00"));
        Console.WriteLine("Perimeter: " + CalculatePerimeter().ToString("0.00"));
    }
}