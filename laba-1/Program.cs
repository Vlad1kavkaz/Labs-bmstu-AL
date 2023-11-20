
using System;


class Rectangle
{
    private double side1;
    private double side2;

    public Rectangle(double sideA, double sideB)
    {
        side1 = sideA;
        side2 = sideB;
    }

    private double CalculateArea()
    {
        return side1 * side2;
    }

    private double CalculatePerimeter()
    {
        return 2 * (side1 + side2);
    }

    public double Area
    {
        get { return CalculateArea(); }
    }

    public double Perimeter
    {
        get { return CalculatePerimeter(); }
    }
}

class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X
    {
        get { return x; }
    }

    public int Y
    {
        get { return y; }
    }
}

class Figure
{
    private Point[] points;
    private string name;

    public Figure(Point point1, Point point2, Point point3, Point point4, Point point5)
    {
        points = new Point[5];
        points[0] = point1;
        points[1] = point2;
        points[2] = point3;
        points[3] = point4;
        points[4] = point5;
        name = "Многоугольник";
    }

    public Figure(Point point1, Point point2, Point point3, Point point4)
    {
        points = new Point[4];
        points[0] = point1;
        points[1] = point2;
        points[2] = point3;
        points[3] = point4;
        name = "Четырехугольник";
    }

    public Figure(Point point1, Point point2, Point point3)
    {
        points = new Point[3];
        points[0] = point1;
        points[1] = point2;
        points[2] = point3;
        name = "Треугольник";
    }

    public void PerimeterCalculator()
    {
        double perimeter = 0;

        for (int i = 0; i < points.Length - 1; i++)
        {
            perimeter += LengthSide(points[i], points[i + 1]);
        }

        perimeter += LengthSide(points[points.Length - 1], points[0]);

        Console.WriteLine("Название фигуры: " + name);
        Console.WriteLine("Периметр: " + perimeter);
    }

    private double LengthSide(Point A, Point B)
    {
        int sideX = B.X - A.X;
        int sideY = B.Y - A.Y;

        return Math.Sqrt(sideX * sideX + sideY * sideY);
    }
}

class Program
{
    static void Main(string[] args)
    {
        //Задание 1
        Console.WriteLine("Задание 1");
        Console.WriteLine("Минимальные и максимальные значения предопределенных типов данных CTS:");

        Console.WriteLine("Тип byte: Минимальное значение = " + byte.MinValue + ", Максимальное значение = " + byte.MaxValue);
        Console.WriteLine("Тип sbyte: Минимальное значение = " + sbyte.MinValue + ", Максимальное значение = " + sbyte.MaxValue);
        Console.WriteLine("Тип short: Минимальное значение = " + short.MinValue + ", Максимальное значение = " + short.MaxValue);
        Console.WriteLine("Тип ushort: Минимальное значение = " + ushort.MinValue + ", Максимальное значение = " + ushort.MaxValue);
        Console.WriteLine("Тип int: Минимальное значение = " + int.MinValue + ", Максимальное значение = " + int.MaxValue);
        Console.WriteLine("Тип uint: Минимальное значение = " + uint.MinValue + ", Максимальное значение = " + uint.MaxValue);
        Console.WriteLine("Тип long: Минимальное значение = " + long.MinValue + ", Максимальное значение = " + long.MaxValue);
        Console.WriteLine("Тип ulong: Минимальное значение = " + ulong.MinValue + ", Максимальное значение = " + ulong.MaxValue);
        Console.WriteLine("Тип float: Минимальное значение = " + float.MinValue + ", Максимальное значение = " + float.MaxValue);
        Console.WriteLine("Тип double: Минимальное значение = " + double.MinValue + ", Максимальное значение = " + double.MaxValue);
        Console.WriteLine("Тип decimal: Минимальное значение = " + decimal.MinValue + ", Максимальное значение = " + decimal.MaxValue);
        Console.WriteLine("Тип char: Минимальное значение = " + char.MinValue + ", Максимальное значение = " + char.MaxValue);
        //Задание 2
        Console.WriteLine("Задание 2");
        Console.Write("Введите длину первой стороны прямоугольника: ");
        double side1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите длину второй стороны прямоугольника: ");
        double side2 = Convert.ToDouble(Console.ReadLine());

        Rectangle rectangle = new Rectangle(side1, side2);

        double area = rectangle.Area;
        double perimeter = rectangle.Perimeter;

        Console.WriteLine("Площадь прямоугольника: " + area);
        Console.WriteLine("Периметр прямоугольника: " + perimeter);
        //Задание 3
        Console.WriteLine("Задание 3");
        Point point1 = new Point(0, 0);
        Point point2 = new Point(0, 5);
        Point point3 = new Point(5, 5);
        Point point4 = new Point(5, 0);
        Point point5 = new Point(0, 0);

        Figure figure = new Figure(point1, point2, point3, point4, point5);
        figure.PerimeterCalculator();
    }
}
