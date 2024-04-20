using Microsoft.AspNetCore.Mvc;

namespace ToyStoreManagement.Pages
{
    public class Logout : Controller
    {
        public IActionResult OnPost()
        {
            HttpContext.Session.Remove("AccountId");
            HttpContext.Session.Remove("RoleId");
            HttpContext.Session.Remove("Name");
            return RedirectToPage("/Index");
        }
    }
}
