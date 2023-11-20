using System;
using System.Collections.Generic;

namespace VectorApp
{
    // Задание №1
    struct Vector
    {
        public int X;
        public int Y;
        public int Z;

        // Переопределение оператора сложения векторов
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z + v2.Z };
        }

        // Переопределение оператора умножения векторов
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector { X = v1.X * v2.X, Y = v1.Y * v2.Y, Z = v1.Z * v2.Z };
        }

        // Переопределение оператора умножения вектора на число
        public static Vector operator *(Vector v, int num)
        {
            return new Vector { X = v.X * num, Y = v.Y * num, Z = v.Z * num };
        }

        // Переопределение логических операторов
        public static bool operator ==(Vector v1, Vector v2)
        {
            int length1 = (int)Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            int length2 = (int)Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
            return length1 == length2;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            int length1 = (int)Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y + v1.Z * v1.Z);
            int length2 = (int)Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y + v2.Z * v2.Z);
            return length1 != length2;
        }
    }

    // Задание №2
    class Car : IEquatable<Car>
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public int MaxSpeed { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public bool Equals(Car other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && string.Equals(Engine, other.Engine) && MaxSpeed == other.MaxSpeed;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Car)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Engine != null ? Engine.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ MaxSpeed;
                return hashCode;
            }
        }
    }

    // Задание №2
    class CarsCatalog
    {
        private List<Car> cars = new List<Car>();

        // Переопределение индексатора
        public string this[int index]
        {
            get { return $"{cars[index].Name}, {cars[index].Engine}"; }
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }
    }

    // Задание №3
    class Currency
    {
        public double Value { get; set; }
    }

    class CurrencyUSD : Currency
    {
        public static explicit operator CurrencyEUR(CurrencyUSD usd)
        {
            double rate = 0.85; // Курс обмена USD -> EUR
            CurrencyEUR eur = new CurrencyEUR { Value = usd.Value * rate };
            return eur;
        }

        public static explicit operator CurrencyRUB(CurrencyUSD usd)
        {
            double rate = 70.0; // Курс обмена USD -> RUB
            CurrencyRUB rub = new CurrencyRUB { Value = usd.Value * rate };

            return rub;
        }
    }

    class CurrencyEUR : Currency
    {
        public static explicit operator CurrencyUSD(CurrencyEUR eur)
        {
            double rate = 1.18; // Курс обмена EUR -> USD
            CurrencyUSD usd = new CurrencyUSD { Value = eur.Value * rate };
            return usd;
        }

        public static explicit operator CurrencyRUB(CurrencyEUR eur)
        {
            double rate = 82.0; // Курс обмена EUR -> RUB
            CurrencyRUB rub = new CurrencyRUB { Value = eur.Value * rate };
            return rub;
        }
    }

    class CurrencyRUB : Currency
    {
        public static explicit operator CurrencyUSD(CurrencyRUB rub)
        {
            double rate = 0.014; // Курс обмена RUB -> USD
            CurrencyUSD usd = new CurrencyUSD { Value = rub.Value * rate };
            return usd;
        }

        public static explicit operator CurrencyEUR(CurrencyRUB rub)
        {
            double rate = 0.012; // Курс обмена RUB -> EUR
            CurrencyEUR eur = new CurrencyEUR { Value = rub.Value * rate };
            return eur;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Задание №1 - пример использования
            Console.WriteLine("Задание 1");
            Vector v1 = new Vector { X = 1, Y = 2, Z = 3 };
            Vector v2 = new Vector { X = 4, Y = 5, Z = 6 };
            Vector v3 = v1 + v2;
            Vector v4 = v1 * v2;
            Vector v5 = v1 * 2;
            bool isEqual = v1 == v2;

            Console.WriteLine($"v3 = ({v3.X}, {v3.Y}, {v3.Z})");
            Console.WriteLine($"v4 = ({v4.X}, {v4.Y}, {v4.Z})");
            Console.WriteLine($"v5 = ({v5.X}, {v5.Y}, {v5.Z})");
            Console.WriteLine($"v1 == v2: {isEqual}");

            // Задание №2 - пример использования
            Console.WriteLine("Задание 2");

            Car car1 = new Car { Name = "BMW", Engine = "V8", MaxSpeed = 250 };
            Car car2 = new Car { Name = "Audi", Engine = "V6", MaxSpeed = 240 };
            bool isCarEqual = car1.Equals(car2);

            Console.WriteLine($"Car1: {car1}, Car2: {car2}");
            Console.WriteLine($"car1 equals car2: {isCarEqual}");

            // Задание №3 - пример использования
            Console.WriteLine("Задание 3");

            CurrencyUSD usd = new CurrencyUSD { Value = 100 };
            CurrencyEUR eur = (CurrencyEUR)usd;
            CurrencyRUB rub = (CurrencyRUB)usd;

            Console.WriteLine($"USD: {usd.Value}, EUR: {eur.Value}, RUB: {rub.Value}");
        }
    }
}
