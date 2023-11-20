using Microsoft.EntityFrameworkCore;
using TaxiModels;

namespace TaxiServices
{
    public class SqlCarsRepository : ICarsRepository
    {
        private readonly AppDbContext __db;

        public SqlCarsRepository(AppDbContext db)
        {
            __db = db;
        }

        public Car Add(Car car)
        {
            __db.Cars.Add(car);
            __db.SaveChanges();
            return car;
        }

        public Car Delete(int id)
        {
            var carToDelete = __db.Cars.Find(id);

            if (carToDelete != null)
            {
                __db.Cars.Remove(carToDelete);
                __db.SaveChanges();
            }
            return carToDelete;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return __db.Cars.ToList();
        }

        public Car? GetCar(int id)
        {
            return __db.Cars.Find(id);
        }

        public Car Update(Car uCar)
        {
            var car = __db.Cars.Attach(uCar);
            car.State = EntityState.Modified;
            __db.SaveChanges();
            return uCar;
        }
    }
}
