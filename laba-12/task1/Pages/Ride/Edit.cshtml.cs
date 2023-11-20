using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Ride
{
    public class EditModel : PageModel
    {
        private readonly IRidesRepository ridesRepository;

        public EditModel(IRidesRepository ridesRepository)
        {
            this.ridesRepository = ridesRepository;
        }

        [BindProperty]
        public TaxiModels.Ride Ride { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Ride = ridesRepository.GetRide(id.Value);
            }
            else
            {
                Ride = new TaxiModels.Ride();
            }

            if (Ride == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(TaxiModels.Ride ride)
        {
            if (Ride.RideId > 0)
            {
                Ride = ridesRepository.Update(ride);
            }
            else
            {
                Ride = ridesRepository.Add(ride);
            }

            return RedirectToPage("/Tickets/Tickets");
        }
    }
}
