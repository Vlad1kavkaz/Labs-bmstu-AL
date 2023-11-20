using TaxiModels; // Импортируем пространство имен для моделей таксопарка

namespace TaxiServices
{
    public class MockCarsRepository : ICarsRepository
    {
        private List<Car> __cars;

        public MockCarsRepository()
        {
            __cars = new List<Car>()
            {
                new Car()
                {
                    CarId = 0,
                    Model = "Toyota Prius",
                    PlateNumber = "ABC123"
                },
                new Car()
                {
                    CarId = 1,
                    Model = "Honda Civic",
                    PlateNumber = "XYZ789"
                },
                new Car()
                {
                    CarId = 2,
                    Model = "Chevrolet Malibu",
                    PlateNumber = "123DEF"
                }
            };
        }

        public Car Add(Car car)
        {
            car.CarId = __cars.Max(x => x.CarId) + 1;
            __cars.Add(car);
            return car;
        }

        public Car Delete(int id)
        {
            var car = __cars.FirstOrDefault(c => c.CarId == id);
            if (car != null)
            {
                __cars.Remove(car);
            }
            return car;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return __cars;
        }

        public Car? GetCar(int id)
        {
            return __cars.FirstOrDefault(c => c.CarId == id);
        }

        public Car Update(Car uCar)
        {
            Car car = __cars.FirstOrDefault(c => c.CarId == uCar.CarId);
            if (car != null)
            {
                car.CarId = uCar.CarId;
                car.Model = uCar.Model;
                car.PlateNumber = uCar.PlateNumber;
            }
            return car;
        }
    }
}
