using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Ride
{
	public class RideModel : PageModel
    {
        private IRidesRepository __db;

        public RideModel(IRidesRepository db)
        {
            __db = db;
        }

        public IEnumerable<TaxiModels.Ride> Ride { get; set; }

        public void OnGet()
        {
            Ride = __db.GetAllRides();
        }
    }
}
