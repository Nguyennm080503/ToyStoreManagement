using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class MyProfileModel : PageModel
    {
        private readonly IAccountService _accountService;

        public MyProfileModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> OnGet()
        {
            var idaccount = HttpContext.Session.GetInt32("AccountId");
        }
    }
}
