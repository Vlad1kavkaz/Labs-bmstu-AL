using TaxiModels; // Импортируем пространство имен для моделей таксопарка

namespace TaxiServices
{
    public interface ICarsRepository
    {
        IEnumerable<Car> GetAllCars();
        Car? GetCar(int id);
        Car Add(Car car);
        Car Update(Car updatedCar);
        Car Delete(int id);
    }
}
