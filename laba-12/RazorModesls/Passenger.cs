namespace TaxiModels
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
    }

    public class Ride
    {
        public int RideId { get; set; }
        public int DriverId { get; set; }
        public decimal Fare { get; set; }
    }

    public class Car
    {
        public int CarId { get; set; }
        public string Model { get; set; }
        public string PlateNumber { get; set; }
    }
}
