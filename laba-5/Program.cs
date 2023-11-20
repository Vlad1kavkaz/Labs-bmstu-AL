using System;
using System.Collections;


//Задание 1
class MyMatrix
{
    private int[,] matrix;
    private int rows;
    private int columns;
    private int minValue;
    private int maxValue;
    private Random random;

    public MyMatrix(int rows, int columns, int minValue, int maxValue)
    {
        this.rows = rows;
        this.columns = columns;
        this.minValue = minValue;
        this.maxValue = maxValue;
        random = new Random();

        Fill();
    }

    public void Fill()
    {
        matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue);
            }
        }
    }

    public void ChangeSize(int newRows, int newColumns)
    {
        int[,] newMatrix = new int[newRows, newColumns];
        for (int i = 0; i < Math.Min(rows, newRows); i++)
        {
            for (int j = 0; j < Math.Min(columns, newColumns); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        if (newRows > rows || newColumns > columns)
        {
            for (int i = Math.Min(rows, newRows); i < newRows; i++)
            {
                for (int j = Math.Min(columns, newColumns); j < newColumns; j++)
                {
                    newMatrix[i, j] = random.Next(minValue, maxValue);
                }
            }
        }

        matrix = newMatrix;
        rows = newRows;
        columns = newColumns;
    }

    public void ShowPartialy(int startRow, int endRow, int startColumn, int endColumn)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public int this[int index1, int index2]
    {
        get { return matrix[index1, index2]; }
        set { matrix[index1, index2] = value; }
    }
}

//Задание 2
class MyList<T>
{
    private T[] array;

    public int Count { get; private set; }

    public MyList()
    {
        array = new T[0];
        Count = 0;
    }

    public T this[int index]
    {
        get { return array[index]; }
        set { array[index] = value; }
    }

    public void Add(T item)
    {
        Array.Resize(ref array, Count + 1);
        array[Count] = item;
        Count++;
    }
}

//Задание 3
class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private List<TKey> keys;
    private List<TValue> values;

    public int Count { get; private set; }

    public MyDictionary()
    {
        keys = new List<TKey>();
        values = new List<TValue>();
        Count = 0;
    }

    public TValue this[TKey key]
    {
        get
        {
            int index = keys.IndexOf(key);
            if (index == -1)
            {
                throw new KeyNotFoundException();
            }
            return values[index];
        }
        set
        {
            int index = keys.IndexOf(key);
            if (index != -1)
            {
                values[index] = value;
            }
            else
            {
                keys.Add(key);
                values.Add(value);
                Count++;
            }
        }
    }

    public void Add(TKey key, TValue value)
    {
        int index = keys.IndexOf(key);
        if (index != -1)
        {
            throw new ArgumentException("An item with the same key has already been added.");
        }
        keys.Add(key);
        values.Add(value);
        Count++;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
        }
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
        Console.Write("Enter number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Enter minimum value: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Enter maximum value: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, columns, minValue, maxValue);

        Console.WriteLine("Matrix:");
        matrix.Show();

        Console.Write("Enter new number of rows: ");
        int newRows = int.Parse(Console.ReadLine());

        Console.Write("Enter new number of columns: ");
        int newColumns = int.Parse(Console.ReadLine());

        matrix.ChangeSize(newRows, newColumns);

        Console.WriteLine("Resized matrix:");
        matrix.Show();

        Console.WriteLine("Enter indices to show partially (startRow, endRow, startColumn, endColumn):");
        int startRow = int.Parse(Console.ReadLine());
        int endRow = int.Parse(Console.ReadLine());
        int startColumn = int.Parse(Console.ReadLine());
        int endColumn = int.Parse(Console.ReadLine());

        Console.WriteLine("Partial matrix:");

        matrix.ShowPartialy(startRow, endRow, startColumn, endColumn);

        Console.WriteLine("Enter indices to change value (index1, index2, value):");
        int index1 = int.Parse(Console.ReadLine());
        int index2 = int.Parse(Console.ReadLine());
        int value = int.Parse(Console.ReadLine());

        matrix[index1, index2] = value;

        Console.WriteLine("Updated matrix:");
        matrix.Show();



        Console.WriteLine("Задание 2");
        MyList<int> myList = new MyList<int>();
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine("Count: " + myList.Count);
        Console.WriteLine("First item: " + myList[0]);

        myList[1] = 4;

        Console.WriteLine("Updated item: " + myList[1]);

        Console.WriteLine("Задание 3");
        MyDictionary<string, int> myDictionary = new MyDictionary<string, int>();
        myDictionary.Add("One", 1);
        myDictionary.Add("Two", 2);
        myDictionary.Add("Three", 3);

        Console.WriteLine("Count: " + myDictionary.Count);

        Console.WriteLine("Values:");
        foreach (KeyValuePair<string, int> kvp in myDictionary)
        {
            Console.WriteLine(kvp.Key + ": " + kvp.Value);
        }

        Console.WriteLine("Value for key 'Two': " + myDictionary["Two"]);

        myDictionary["Two"] = 4;

        Console.WriteLine("Updated value for key 'Two': " + myDictionary["Two"]);
    }
}
