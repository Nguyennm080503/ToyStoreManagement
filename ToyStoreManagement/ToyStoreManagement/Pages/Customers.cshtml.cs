using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class CustomersModel : PageModel
    {
        private readonly IAccountService _accountService;
        public IEnumerable<Account> Accounts { get; set; }
        public int ListNumber { get; set; }
        public CustomersModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> OnGet()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if(roleId == 1 || roleId == 2)
            {
                Accounts = _accountService.GetAllCustomerAccounts();
                ListNumber = Accounts.Count();
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }
        }
    }
}
