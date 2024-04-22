using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class MyProfileModel : PageModel
    {
        private readonly IAccountService _accountService;
        public Account Account { get; set; }

        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Phone { get; set; }
        [BindProperty] public string Address { get; set; }

        public string Message { get; set; }

        public MyProfileModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> OnGet()
        {
            var idaccount = HttpContext.Session.GetInt32("AccountId");
            if(idaccount != 0)
            {
                Account = _accountService.GetProfileAccount((int)idaccount);
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }
        }
        public async Task<IActionResult> OnPost()
        {
            var idaccount = HttpContext.Session.GetInt32("AccountId");
            if (idaccount != 0)
            {
                Account = _accountService.GetProfileAccount((int)idaccount);
                Account.Phone = Phone;
                Account.Address = Address;
                Account.Name = Name;
                bool isUpdate = _accountService.UpdateProfileAccount(Account);
                if (isUpdate)
                {
                    Message = "Update profile successfully!";
                    return Page();
                }
                else
                {
                    Message = "Have some error. Try again!";
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("/Login");
            }
        }
    }
}
