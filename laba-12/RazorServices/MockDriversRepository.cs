using TaxiModels; // Импортируем пространство имен для моделей таксопарка

namespace TaxiServices
{
    public class MockDriversRepository : IDriversRepository
    {
        private List<Driver> __drivers;

        public MockDriversRepository()
        {
            __drivers = new List<Driver>()
            {
                new Driver()
                {
                    DriverId = 0,
                    Name = "Andrew",
                    LicenseNumber = "ABC123"
                },
                new Driver()
                {
                    DriverId = 1,
                    Name = "Alice",
                    LicenseNumber = "XYZ456"
                },
                new Driver()
                {
                    DriverId = 2,
                    Name = "Vova",
                    LicenseNumber = "DEF789"
                }
            };
        }

        public Driver Add(Driver driver)
        {
            driver.DriverId = __drivers.Max(x => x.DriverId) + 1;
            __drivers.Add(driver);
            return driver;
        }

        public Driver Delete(int id)
        {
            var driver = __drivers.FirstOrDefault(d => d.DriverId == id);
            if (driver != null)
            {
                __drivers.Remove(driver);
            }
            return driver;
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return __drivers;
        }

        public Driver? GetDriver(int id)
        {
            return __drivers.FirstOrDefault(d => d.DriverId == id);
        }

        public Driver Update(Driver updatedDriver)
        {
            Driver driver = __drivers.FirstOrDefault(d => d.DriverId == updatedDriver.DriverId);
            if (driver != null)
            {
                driver.Name = updatedDriver.Name;
                driver.LicenseNumber = updatedDriver.LicenseNumber;
            }
            return driver;
        }
    }
}
