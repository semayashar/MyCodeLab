internal class Figure
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