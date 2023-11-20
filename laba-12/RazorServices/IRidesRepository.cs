using TaxiModels; // Импортируем пространство имен для моделей таксопарка

namespace TaxiServices
{
    public interface IRidesRepository
    {
        IEnumerable<Ride> GetAllRides();
        Ride? GetRide(int id);
        Ride Add(Ride ride);
        Ride Update(Ride updatedRide);
        Ride Delete(int id);
    }
}
