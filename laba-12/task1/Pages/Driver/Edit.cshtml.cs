using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Driver
{
    public class EditModel : PageModel
    {
        private readonly IDriversRepository driversRepository;

        public EditModel(IDriversRepository driversRepository)
        {
            this.driversRepository = driversRepository;
        }

        [BindProperty]
        public TaxiModels.Driver Driver { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Driver = driversRepository.GetDriver(id.Value);
            }
            else
            {
                Driver = new TaxiModels.Driver();
            }

            if (Driver == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(TaxiModels.Driver driver)
        {
            if (Driver.DriverId > 0)
            {
                Driver = driversRepository.Update(driver);
            }
            else
            {
                Driver = driversRepository.Add(driver);
            }

            return RedirectToPage("/Trains/Trains");
        }
    }
}
