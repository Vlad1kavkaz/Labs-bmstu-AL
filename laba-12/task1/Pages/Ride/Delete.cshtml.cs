using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Ride
{
    public class DeleteModel : PageModel
    {
        private IRidesRepository __db;
        public DeleteModel(IRidesRepository db)
        {
            __db = db;
        }

        [BindProperty]
        public TaxiModels.Ride Ride { get; set; }

        public IActionResult OnGet(int id)
        {
            Ride = __db.GetRide(id);
            if (Ride == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Ride = __db.Delete(Ride.RideId);
            if (Ride == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Tickets/Tickets");
        }
    }
}
