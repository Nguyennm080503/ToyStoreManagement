using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ToyStoreManagement.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
			HttpContext.Session.Remove("AccountId");
            HttpContext.Session.Remove("RoleId");
            HttpContext.Session.Remove("Name");

            return RedirectToPage("/Index");
		}
	}
}
