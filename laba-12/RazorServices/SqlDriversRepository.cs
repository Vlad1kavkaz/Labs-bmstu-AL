using Microsoft.EntityFrameworkCore;
using TaxiModels;

namespace TaxiServices
{
    public class SqlDriversRepository : IDriversRepository
    {
        private readonly AppDbContext __db;

        public SqlDriversRepository(AppDbContext db)
        {
            __db = db;
        }

        public Driver Add(Driver driver)
        {
            __db.Drivers.Add(driver);
            __db.SaveChanges();
            return driver;
        }

        public Driver Delete(int id)
        {
            var driverToDelete = __db.Drivers.Find(id);

            if (driverToDelete != null)
            {
                __db.Drivers.Remove(driverToDelete);
                __db.SaveChanges();
            }
            return driverToDelete;
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return __db.Drivers.ToList();
        }

        public Driver? GetDriver(int id)
        {
            return __db.Drivers.Find(id);
        }

        public Driver Update(Driver updatedDriver)
        {
            var driver = __db.Drivers.Attach(updatedDriver);
            driver.State = EntityState.Modified;
            __db.SaveChanges();
            return updatedDriver;
        }
    }
}
