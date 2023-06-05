internal class Triangle : Figure
{
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC)
    {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    public override double CalculateArea()
    {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
    }

    public override double CalculatePerimeter()
    {
        return sideA + sideB + sideC;
    }

    public override void PrintDetails()
    {
        Console.WriteLine("Triangle:");
        Console.WriteLine("Side A: " + sideA.ToString("0.00") + " cm");
        Console.WriteLine("Side B: " + sideB.ToString("0.00") + " cm");
        Console.WriteLine("Side C: " + sideC.ToString("0.00") + " cm");
        Console.WriteLine("Area: " + CalculateArea().ToString("0.00"));
        Console.WriteLine("Perimeter: " + CalculatePerimeter().ToString("0.00"));
    }
}