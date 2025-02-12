using System;
namespace Shapes;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();

        Square square = new Square("red", 5);
        shapes.Add(square);
        square.GetArea();
        square.GetColor();

        Rectangle rectangle = new Rectangle("Blue", 3, 5);
        shapes.Add(rectangle);

        Circle circle = new Circle("Orange", 5);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();

            double area = Math.Round(shape.GetArea(), 2);

            Console.WriteLine($"The {color} shape has an area of {area}");
        }


    }
}