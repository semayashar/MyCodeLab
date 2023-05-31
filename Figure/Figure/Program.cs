using System;

class Figure
{
    public virtual double CalculateArea()
    {
        return 0;
    }

    public virtual double CalculatePerimeter()
    {
        return 0;
    }

    public virtual void PrintDetails()
    {
        Console.WriteLine("No details available for this figure.");
    }
}

class Circle : Figure
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

class Rectangle : Figure
{
    private double length;
    private double width;

    public Rectangle(double length, double width)
    {
        this.length = length;
        this.width = width;
    }

    public override double CalculateArea()
    {
        return length * width;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (length + width);
    }

    public override void PrintDetails()
    {
        Console.WriteLine("Rectangle:");
        Console.WriteLine("Length: " + length.ToString("0.00") + " cm");
        Console.WriteLine("Width: " + width.ToString("0.00") + " cm");
        Console.WriteLine("Area: " + CalculateArea().ToString("0.00"));
        Console.WriteLine("Perimeter: " + CalculatePerimeter().ToString("0.00"));
    }
}

class Triangle : Figure
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

class Square : Figure
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

class Ellipse : Figure
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

class Program
{
    static void Main(string[] args)
    {
        Figure circle = new Circle(5);
        circle.PrintDetails();

        Figure rectangle = new Rectangle(3, 4);
        rectangle.PrintDetails();

        Figure triangle = new Triangle(3, 4, 5);
        triangle.PrintDetails();

        Figure square = new Square(6);
        square.PrintDetails();

        Figure ellipse = new Ellipse(8, 4);
        ellipse.PrintDetails();
    }
}
