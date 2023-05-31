using System;
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

