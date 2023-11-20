using TaxiModels;

namespace TaxiServices
{
    public class MockRidesRepository : IRidesRepository
    {
        private List<Ride> __rides;

        public MockRidesRepository()
        {
            __rides = new List<Ride>()
            {
                new Ride()
                {
                    RideId = 0,
                    DriverId = 0,
                    Fare = 30.0m
                },
                new Ride()
                {
                    RideId = 1,
                    DriverId = 1,
                    Fare = 40.0m
                },
                new Ride()
                {
                    RideId = 2,
                    DriverId = 2,
                    Fare = 50.0m
                }
            };
        }

        public Ride Add(Ride ride)
        {
            ride.RideId = __rides.Max(x => x.RideId) + 1;
            __rides.Add(ride);
            return ride;
        }

        public Ride Delete(int id)
        {
            var ride = __rides.FirstOrDefault(r => r.RideId == id);
            if (ride != null)
            {
                __rides.Remove(ride);
            }
            return ride;
        }

        public IEnumerable<Ride> GetAllRides()
        {
            return __rides;
        }

        public Ride? GetRide(int id)
        {
            return __rides.FirstOrDefault(r => r.RideId == id);
        }

        public Ride Update(Ride updatedRide)
        {
            Ride ride = __rides.FirstOrDefault(r => r.RideId == updatedRide.RideId);
            if (ride != null)
            {
                ride.DriverId = updatedRide.DriverId;
                ride.Fare = updatedRide.Fare;
            }
            return ride;
        }
    }
}
