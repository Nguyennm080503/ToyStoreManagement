using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class StaffsModel : PageModel
    {
        private readonly IAccountService _accountService;
        public IEnumerable<Account> Accounts { get; set; }

        public StaffsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> OnGet()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId != 1 || roleId != 2)
            {
                return RedirectToPage("/Login");
            }
            else
            {
                Accounts = _accountService.GetAllStaffAccounts();
                return Page();
            }
        }
    }
}
