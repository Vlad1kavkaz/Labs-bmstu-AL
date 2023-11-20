using TaxiModels; // Импортируем пространство имен для моделей таксопарка

namespace TaxiServices
{
    public interface IDriversRepository
    {
        IEnumerable<Driver> GetAllDrivers();
        Driver? GetDriver(int id);
        Driver Add(Driver driver);
        Driver Update(Driver updatedDriver);
        Driver Delete(int id);
    }
}
