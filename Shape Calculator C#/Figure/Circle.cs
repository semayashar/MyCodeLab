internal class Circle : Figure
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * radius * radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override void PrintDetails()
    {
        Console.WriteLine("Circle:");
        Console.WriteLine("Radius: " + radius.ToString("0.00") + " cm");
        Console.WriteLine("Area: " + CalculateArea().ToString("0.00"));
        Console.WriteLine("Perimeter: " + CalculatePerimeter().ToString("0.00"));
    }
}