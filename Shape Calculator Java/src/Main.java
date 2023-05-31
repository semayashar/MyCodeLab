import java.text.DecimalFormat;

abstract class Figure {
    public abstract double calculateArea();
    public abstract double calculatePerimeter();
    public abstract void printDetails();
}

class Circle extends Figure {
    private double radius;

    public Circle(double radius) {
        this.radius = radius;
    }

    @Override
    public double calculateArea() {
        return Math.PI * radius * radius;
    }

    @Override
    public double calculatePerimeter() {
        return 2 * Math.PI * radius;
    }

    @Override
    public void printDetails() {
        DecimalFormat decimalFormat = new DecimalFormat("0.00");
        System.out.println("Circle:");
        System.out.println("Radius: " + decimalFormat.format(radius) + " cm");
        System.out.println("Area: " + decimalFormat.format(calculateArea()));
        System.out.println("Perimeter: " + decimalFormat.format(calculatePerimeter()));
    }
}

class Rectangle extends Figure {
    private double length;
    private double width;

    public Rectangle(double length, double width) {
        this.length = length;
        this.width = width;
    }

    @Override
    public double calculateArea() {
        return length * width;
    }

    @Override
    public double calculatePerimeter() {
        return 2 * (length + width);
    }

    @Override
    public void printDetails() {
        DecimalFormat decimalFormat = new DecimalFormat("0.00");
        System.out.println("Rectangle:");
        System.out.println("Length: " + decimalFormat.format(length) + " cm");
        System.out.println("Width: " + decimalFormat.format(width) + " cm");
        System.out.println("Area: " + decimalFormat.format(calculateArea()));
        System.out.println("Perimeter: " + decimalFormat.format(calculatePerimeter()));
    }
}

class Triangle extends Figure {
    private double sideA;
    private double sideB;
    private double sideC;

    public Triangle(double sideA, double sideB, double sideC) {
        this.sideA = sideA;
        this.sideB = sideB;
        this.sideC = sideC;
    }

    @Override
    public double calculateArea() {
        double semiPerimeter = (sideA + sideB + sideC) / 2;
        return Math.sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
    }

    @Override
    public double calculatePerimeter() {
        return sideA + sideB + sideC;
    }

    @Override
    public void printDetails() {
        DecimalFormat decimalFormat = new DecimalFormat("0.00");
        System.out.println("Triangle:");
        System.out.println("Side A: " + decimalFormat.format(sideA) + " cm");
        System.out.println("Side B: " + decimalFormat.format(sideB) + " cm");
        System.out.println("Side C: " + decimalFormat.format(sideC) + " cm");
        System.out.println("Area: " + decimalFormat.format(calculateArea()));
        System.out.println("Perimeter: " + decimalFormat.format(calculatePerimeter()));
    }
}

class Square extends Figure {
    private double side;

    public Square(double side) {
        this.side = side;
    }

    @Override
    public double calculateArea() {
        return side * side;
    }

    @Override
    public double calculatePerimeter() {
        return 4 * side;
    }

    @Override
    public void printDetails() {
        DecimalFormat decimalFormat = new DecimalFormat("0.00");
        System.out.println("Square:");
        System.out.println("Side: " + decimalFormat.format(side) + " cm");
        System.out.println("Area: " + decimalFormat.format(calculateArea()));
        System.out.println("Perimeter: " + decimalFormat.format(calculatePerimeter()));
    }
}

class Ellipse extends Figure {
    private double majorAxis;
    private double minorAxis;

    public Ellipse(double majorAxis, double minorAxis) {
        this.majorAxis = majorAxis;
        this.minorAxis = minorAxis;
    }

    @Override
    public double calculateArea() {
        return Math.PI * majorAxis * minorAxis;
    }

    @Override
    public double calculatePerimeter() {
        double a = majorAxis / 2;
        double b = minorAxis / 2;
        return 2 * Math.PI * Math.sqrt((a * a + b * b) / 2);
    }

    @Override
    public void printDetails() {
        DecimalFormat decimalFormat = new DecimalFormat("0.00");
        System.out.println("Ellipse:");
        System.out.println("Major Axis: " + decimalFormat.format(majorAxis) + " cm");
        System.out.println("Minor Axis: " + decimalFormat.format(minorAxis) + " cm");
        System.out.println("Area: " + decimalFormat.format(calculateArea()));
        System.out.println("Perimeter: " + decimalFormat.format(calculatePerimeter()));
    }
}

public class Main {
    public static void main(String[] args) {
        Figure circle = new Circle(5);
        circle.printDetails();

        Figure rectangle = new Rectangle(3, 4);
        rectangle.printDetails();

        Figure triangle = new Triangle(3, 4, 5);
        triangle.printDetails();

        Figure square = new Square(6);
        square.printDetails();

        Figure ellipse = new Ellipse(8, 4);
        ellipse.printDetails();
    }
}