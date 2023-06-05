internal class Ellipse : Figure
{

    private double majorAxis;
    private double minorAxis;

    public Ellipse(double majorAxis, double minorAxis)
    {
        this.majorAxis = majorAxis;
        this.minorAxis = minorAxis;
    }

    public override double CalculateArea()
    {
        return Math.PI * majorAxis * minorAxis;
    }

    public override double CalculatePerimeter()
    {
        double a = majorAxis / 2;
        double b = minorAxis / 2;
        return 2 * Math.PI * Math.Sqrt((a * a + b * b) / 2);
    }

    public override void PrintDetails()
    {
        Console.WriteLine("Ellipse:");
        Console.WriteLine("Major Axis: " + majorAxis.ToString("0.00") + " cm");
        Console.WriteLine("Minor Axis: " + minorAxis.ToString("0.00") + " cm");
        Console.WriteLine("Area: " + CalculateArea().ToString("0.00"));
        Console.WriteLine("Perimeter: " + CalculatePerimeter().ToString("0.00"));
    }
}