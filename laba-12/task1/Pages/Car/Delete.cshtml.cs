using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Car
{
	public class DeleteModel : PageModel
    {
        private ICarsRepository __db;
        public DeleteModel(ICarsRepository db)
        {
            __db = db;
        }

        [BindProperty]
        public TaxiModels.Car Car { get; set; }

        public IActionResult OnGet(int id)
        {
            Car = __db.GetCar(id);
            if (Car == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Car = __db.Delete(Car.CarId);
            if (Car == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Passengers/Passengers");
        }
    }
}
