using Microsoft.EntityFrameworkCore;
using TaxiModels;

namespace TaxiServices
{
    public class SqlRidesRepository : IRidesRepository
    {
        private readonly AppDbContext __db;

        public SqlRidesRepository(AppDbContext db)
        {
            __db = db;
        }

        public Ride Add(Ride ride)
        {
            __db.Rides.Add(ride);
            __db.SaveChanges();
            return ride;
        }

        public Ride Delete(int id)
        {
            var rideToDelete = __db.Rides.Find(id);

            if (rideToDelete != null)
            {
                __db.Rides.Remove(rideToDelete);
                __db.SaveChanges();
            }
            return rideToDelete;
        }

        public IEnumerable<Ride> GetAllRides()
        {
            return __db.Rides.ToList();
        }

        public Ride? GetRide(int id)
        {
            return __db.Rides.Find(id);
        }

        public Ride Update(Ride updatedRide)
        {
            var ride = __db.Rides.Attach(updatedRide);
            ride.State = EntityState.Modified;
            __db.SaveChanges();
            return updatedRide;
        }
    }
}
