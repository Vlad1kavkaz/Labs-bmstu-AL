using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Car
{
	public class EditModel : PageModel
    {
        private readonly ICarsRepository carsRepository;

        public EditModel(ICarsRepository passengersRepository)
        {
            this.carsRepository = passengersRepository;
        }

        [BindProperty]
        public TaxiModels.Car Car { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Car = carsRepository.GetCar(id.Value);
            } else
            {
                Car = new TaxiModels.Car();
            }

            if (Car == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(TaxiModels.Car car)
        {
            if (Car.CarId > 0)
            {
                Car = carsRepository.Update(car);
            } else
            {
                Car = carsRepository.Add(car);
            }
            
            return RedirectToPage("/Passengers/Passengers");
        }
    }
}
