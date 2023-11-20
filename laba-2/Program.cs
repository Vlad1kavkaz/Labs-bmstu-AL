using System;

namespace ClassRoomApp
{
    // Задание №1

    // Создаем класс ученик - Pupil
    class Pupil
    {
        public virtual void Study()
        {
            Console.WriteLine("Pupil is studying");
        }

        public virtual void Read()
        {
            Console.WriteLine("Pupil is reading");
        }

        public virtual void Write()
        {
            Console.WriteLine("Pupil is writing");
        }

        public virtual void Relax()
        {
            Console.WriteLine("Pupil is relaxing");
        }
    }

    // Создаем производный класс ExcellentPupil
    class ExcellentPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Excellent pupil is studying");
        }

        public override void Read()
        {
            Console.WriteLine("Excellent pupil is reading");
        }

        public override void Write()
        {
            Console.WriteLine("Excellent pupil is writing");
        }

        public override void Relax()
        {
            Console.WriteLine("Excellent pupil is relaxing");
        }
    }

    // Создаем производный класс GoodPupil
    class GoodPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Good pupil is studying");
        }

        public override void Read()
        {
            Console.WriteLine("Good pupil is reading");
        }

        public override void Write()
        {
            Console.WriteLine("Good pupil is writing");
        }

        public override void Relax()
        {
            Console.WriteLine("Good pupil is relaxing");
        }
    }

    // Создаем производный класс BadPupil
    class BadPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Bad pupil is studying");
        }

        public override void Read()
        {
            Console.WriteLine("Bad pupil is reading");
        }

        public override void Write()
        {
            Console.WriteLine("Bad pupil is writing");
        }

        public override void Relax()
        {
            Console.WriteLine("Bad pupil is relaxing");
        }
    }

    // Создаем класс ClassRoom
    class ClassRoom
    {
        private Pupil[] pupils;

        public ClassRoom(params Pupil[] students)
        {
            pupils = students;
        }

        public void ShowInfo()
        {
            foreach (var pupil in pupils)
            {
                Console.WriteLine("Pupil's abilities:");
                pupil.Study();
                pupil.Read();
                pupil.Write();
                pupil.Relax();
                Console.WriteLine("-------------");
            }
        }
    }

    // Задание №2

    // Базовый класс Vehicle
    class Vehicle
    {
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public double Price { get; set; }
        public double Speed { get; set; }
        public int Year { get; set; }

        public Vehicle(double x, double y, double price, double speed, int year)
        {
            CoordinateX = x;
            CoordinateY = y;
            Price = price;
            Speed = speed;
            Year = year;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine("COORDINATES: {0}, {1}", CoordinateX, CoordinateY);
            Console.WriteLine("PRICE: {0}", Price);
            Console.WriteLine("SPEED: {0}", Speed);
            Console.WriteLine("YEAR: {0}", Year);
        }
    }

    // Производный класс Plane
    class Plane : Vehicle
    {
        public double Height { get; set; }
        public int Passengers { get; set; }

        public Plane(double x, double y, double price, double speed, int year, double height, int passengers)
            : base(x, y, price, speed, year)
        {
            Height = height;
            Passengers = passengers;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("HEIGHT: {0}", Height);
            Console.WriteLine("PASSENGERS: {0}", Passengers);
        }
    }

    // Производный класс Car
    class Car : Vehicle
    {
        public Car(double x, double y, double price, double speed, int year)
            : base(x, y, price, speed, year)
        {
        }
    }

    // Производный класс Ship
    class Ship : Vehicle
    {
        public int Passengers { get; set; }
        public string Port { get; set; }

        public Ship(double x, double y, double price, double speed, int year, int passengers, string port)
            : base(x, y, price, speed, year)
        {
            Passengers = passengers;
            Port = port;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("PASSENGERS: {0}", Passengers);
            Console.WriteLine("PORT: {0}", Port);
        }
    }

    // Задание №3

    // Базовый класс DocumentWorker
    class DocumentWorker
    {
        public virtual void OpenDocument()
        {
            Console.WriteLine("Document is opened");
        }

        public virtual void EditDocument()
        {
            Console.WriteLine("Editing is available in Pro version");
        }

        public virtual void SaveDocument()
        {
            Console.WriteLine("Saving is available in Pro version");
        }
    }

    // Производный класс ProDocumentWorker
    class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument()
        {
            Console.WriteLine("Document is edited");
        }

        public override void SaveDocument()
        {
            Console.WriteLine("Document is saved in the old format, saving in other formats is available in Expert version");
        }
    }

    // Производный класс ExpertDocumentWorker
    class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Document is saved in the new format");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем учеников разных типов
            Pupil pupil1 = new ExcellentPupil();
            Pupil pupil2 = new GoodPupil();
            Pupil pupil3 = new BadPupil();
            Pupil pupil4 = new ExcellentPupil();

            // Создаем класс ClassRoom сразу с 4 учениками
            ClassRoom classRoom = new ClassRoom(pupil1, pupil2, pupil3, pupil4);
            classRoom.ShowInfo();

            Console.WriteLine();

            // Создание экземпляров различных транспортных средств
            Vehicle[] vehicles = new Vehicle[3];
            vehicles[0] = new Plane(100, 200, 1000000, 800, 2020, 10000, 200);
            vehicles[1] = new Car(50, 100, 50000, 200, 2018);
            vehicles[2] = new Ship(0, 0, 2000000, 60, 2015, 500, "New York");

            // Вывод информации об каждом транспортном средстве
            foreach (var vehicle in vehicles)
            {
                vehicle.ShowInfo();
                Console.WriteLine("-------------");
            }

            Console.WriteLine();

            Console.WriteLine("Enter access key:");
            string key = Console.ReadLine();

            DocumentWorker documentWorker;

            if (key == "pro")
            {
                documentWorker = new ProDocumentWorker();
            }
            else if (key == "exp")
            {
                documentWorker = new ExpertDocumentWorker();
            }
            else
            {
                documentWorker = new DocumentWorker();
            }

            documentWorker.OpenDocument();
            documentWorker.EditDocument();
            documentWorker.SaveDocument();
        }
    }
}
