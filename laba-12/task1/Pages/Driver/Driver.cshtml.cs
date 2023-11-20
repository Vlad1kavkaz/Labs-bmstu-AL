using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Driver
{
	public class DriverModel : PageModel
    {
        private IDriversRepository __db;

        public DriverModel(IDriversRepository db)
        {
            __db = db;
        }

        public IEnumerable<TaxiModels.Driver> Driver { get; set; }

        public void OnGet()
        {
            Driver = __db.GetAllDrivers();
        }
    }
}
