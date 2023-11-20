using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxiServices;

namespace task1.Pages.Driver
{
    public class DeleteModel : PageModel
    {
        private IDriversRepository __db;
        public DeleteModel(IDriversRepository db)
        {
            __db = db;
        }

        [BindProperty]
        public TaxiModels.Driver Driver { get; set; }

        public IActionResult OnGet(int id)
        {
            Driver = __db.GetDriver(id);
            if (Driver == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Driver = __db.Delete(Driver.DriverId);
            if (Driver == null)
            {
                return RedirectToPage("/Error");
            }
            return RedirectToPage("/Tickets/Tickets");
        }
    }
}
