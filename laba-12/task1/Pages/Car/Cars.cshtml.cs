using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Car
{
	public class CarsModel : PageModel
    {
        private ICarsRepository __db;

        public CarsModel(ICarsRepository db)
        {
            __db = db;
        }

        public IEnumerable<TaxiModels.Car> Passengers { get; set; }

        public void OnGet()
        {
            Passengers = __db.GetAllCars();
        }
    }
}
