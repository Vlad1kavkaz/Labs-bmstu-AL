using System;
using System.Collections.Generic;
using System.Collections;
using static CarComparer;



//Задание 1
class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private int rangeMin;
    private int rangeMax;
    private Random random;

    public MyMatrix(int rows, int columns, int rangeMin, int rangeMax)
    {
        this.rows = rows;
        this.columns = columns;
        this.rangeMin = rangeMin;
        this.rangeMax = rangeMax;
        this.random = new Random();

        this.matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                this.matrix[i, j] = random.Next(rangeMin, rangeMax);
            }
        }
    }

    public int getRows()
    { return rows; }

    public int getColums()
    { return columns; }

    public int this[int row, int column]
    {
        get { return matrix[row, column]; }
        set { matrix[row, column] = value; }
    }

    public static MyMatrix operator +(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            throw new ArgumentException("Matrices must have the same dimensions for addition.");

        MyMatrix result = new MyMatrix(matrix1.rows, matrix1.columns, matrix1.rangeMin, matrix1.rangeMax);
        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        return result;
    }

    public static MyMatrix operator -(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.rows != matrix2.rows || matrix1.columns != matrix2.columns)
            throw new ArgumentException("Matrices must have the same dimensions for subtraction.");

        MyMatrix result = new MyMatrix(matrix1.rows, matrix1.columns, matrix1.rangeMin, matrix1.rangeMax);
        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix1.columns; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }
        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix1, MyMatrix matrix2)
    {
        if (matrix1.columns != matrix2.rows)
            throw new ArgumentException("The number of columns in the first matrix must match the number of rows in the second matrix.");

        MyMatrix result = new MyMatrix(matrix1.rows, matrix2.columns, matrix1.rangeMin, matrix1.rangeMax);
        for (int i = 0; i < matrix1.rows; i++)
        {
            for (int j = 0; j < matrix2.columns; j++)
            {
                for (int k = 0; k < matrix1.columns; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }
        return result;
    }

    public static MyMatrix operator *(MyMatrix matrix, int scalar)
    {
        MyMatrix result = new MyMatrix(matrix.rows, matrix.columns, matrix.rangeMin, matrix.rangeMax);
        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    public static MyMatrix operator /(MyMatrix matrix, int scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("The scalar value cannot be zero.");

        MyMatrix result = new MyMatrix(matrix.rows, matrix.columns, matrix.rangeMin, matrix.rangeMax);
        for (int i = 0; i < matrix.rows; i++)
        {
            for (int j = 0; j < matrix.columns; j++)
            {

                result[i, j] = matrix[i, j] / scalar;
            }
        }
        return result;
    }
}

//Задание 2,3

class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
}

class CarComparer : IComparer<Car>
{
    public enum SortBy
    {
        Name,
        ProductionYear,
        MaxSpeed
    }

    public SortBy SortByProperty { get; set; }

    public int Compare(Car x, Car y)
    {
        if (SortByProperty == SortBy.Name)
        {
            return string.Compare(x.Name, y.Name);
        }
        else if (SortByProperty == SortBy.ProductionYear)
        {
            return x.ProductionYear.CompareTo(y.ProductionYear);
        }
        else if (SortByProperty == SortBy.MaxSpeed)
        {
            return x.MaxSpeed.CompareTo(y.MaxSpeed);
        }

        throw new ArgumentException("Invalid sort property");
    }
}

//Задание 3


class CarCatalog : IEnumerable<Car>
{
    private Car[] _cars;

    public CarCatalog(Car[] cars)
    {
        _cars = cars;
    }

    public IEnumerator<Car> GetEnumerator()
    {
        return GetEnumeratorForward();
    }

    private IEnumerator<Car> GetEnumeratorForward()
    {
        for (int i = 0; i< _cars.Length; i++)
        {
            yield return _cars[i];
        }
    }

    private IEnumerable<Car> GetEnumeratorBackward()
    {
        for (int i = _cars.Length - 1; i >= 0; i--)
        {
            yield return _cars[i];
        }
    }

    private IEnumerable<Car> GetEnumeratorByProductionYear(int productionYear)
    {
        foreach (Car car in _cars)
        {
            if (car.ProductionYear == productionYear)
            {
                yield return car;
            }
        }
    }

    private IEnumerable<Car> GetEnumeratorByMaxSpeed(int maxSpeed)
    {
        foreach (Car car in _cars)
        {
            if (car.MaxSpeed == maxSpeed)
            {
                yield return car;
            }
        }
    }

    public IEnumerable<Car> GetEnumeratorReverse()
    {
        return GetEnumeratorBackward();
    }

    public IEnumerable<Car> GetEnumeratorFilterByProductionYear(int productionYear)
    {
        return GetEnumeratorByProductionYear(productionYear);
    }

    public IEnumerable<Car> GetEnumeratorFilterByMaxSpeed(int maxSpeed)
    {
        return GetEnumeratorByMaxSpeed(maxSpeed);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1");
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Enter the minimum value: ");
        int rangeMin= int.Parse(Console.ReadLine());

        Console.Write("Enter the maximum value: ");
        int rangeMax = int.Parse(Console.ReadLine());

        Console.Write("Enter the myltyply value: ");
        int myltyplayBy = int.Parse(Console.ReadLine());

        Console.Write("Enter the division value: ");
        int divisionBy = int.Parse(Console.ReadLine());



        MyMatrix matrix1 = new MyMatrix(rows, columns, rangeMin, rangeMax);
        MyMatrix matrix2 = new MyMatrix(rows, columns, rangeMin, rangeMax);

        MyMatrix sum = matrix1 + matrix2;
        MyMatrix difference = matrix1 - matrix2;
        MyMatrix product = matrix1 * matrix2;
        MyMatrix scalarProduct = matrix1 * myltyplayBy;
        MyMatrix scalarDivision = matrix1 / divisionBy;

        Console.WriteLine("Matrix 1:");
        PrintMatrix(matrix1);
        Console.WriteLine("Matrix 2:");
        PrintMatrix(matrix2);
        Console.WriteLine("Sum:");
        PrintMatrix(sum);
        Console.WriteLine("Difference:");
        PrintMatrix(difference);
        Console.WriteLine("Product:");
        PrintMatrix(product);
        Console.WriteLine("Scalar product:");
        PrintMatrix(scalarProduct);
        Console.WriteLine("Scalar division:");
        PrintMatrix(scalarDivision);

        Console.WriteLine("Задание 2");

        Car[] cars = new Car[]
        {
            new Car { Name = "Toyota", ProductionYear = 2000, MaxSpeed = 180 },
            new Car { Name = "BMW", ProductionYear = 2010, MaxSpeed = 220 },
            new Car { Name = "Audi", ProductionYear = 2015, MaxSpeed = 200 },
            new Car { Name = "Ford", ProductionYear = 1995, MaxSpeed = 160 },
            new Car { Name = "Mercedes", ProductionYear = 2018, MaxSpeed = 240 }
        };

        Console.WriteLine("Выберите по какому признаку сортировать:");
        Console.WriteLine("1. По названию");
        Console.WriteLine("2. По году выпуска");
        Console.WriteLine("3. По максимальной скорости");
        Console.Write("Введите номер выбранного признака: ");
        int sortOption = Convert.ToInt32(Console.ReadLine());

        CarComparer.SortBy sortByProperty;
        switch (sortOption)
        {
            case 1:
                sortByProperty = CarComparer.SortBy.Name;
                break;
            case 2:
                sortByProperty = CarComparer.SortBy.ProductionYear;
                break;
            case 3:
                sortByProperty = CarComparer.SortBy.MaxSpeed;
                break;
            default:
                throw new ArgumentException("Invalid sort option");
        }

        Array.Sort(cars, new CarComparer { SortByProperty = sortByProperty });
        PrintCars(cars);

        Console.WriteLine("Задание 3");

        CarCatalog catalog = new CarCatalog(cars);

        Console.WriteLine("Forward:");
        foreach (Car car in catalog)
        {
            Console.WriteLine(car.Name);
        }

        Console.WriteLine("\nReverse:");
        foreach (Car car in catalog.GetEnumeratorReverse())
        {
            Console.WriteLine(car.Name);
        }

        Console.WriteLine("\nFilter by Production Year (2010):");
        foreach (Car car in catalog.GetEnumeratorFilterByProductionYear(2010))
        {
            Console.WriteLine(car.Name);
        }

        Console.WriteLine("\nFilter by Max Speed (200):");
        foreach (Car car in catalog.GetEnumeratorFilterByMaxSpeed(200))
        {
            Console.WriteLine(car.Name);
        }



    }
    static void PrintCars(Car[] cars)
    {
        foreach (var car in cars)
        {
            Console.WriteLine($"Name: {car.Name}, Production Year: {car.ProductionYear}, Max Speed: {car.MaxSpeed}");
        }
    }
    static void PrintMatrix(MyMatrix matrix)
        {
            for (int i = 0; i < matrix.getRows(); i++)
            {
                for (int j = 0; j < matrix.getColums(); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
