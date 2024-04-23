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
        public int ListNumber { get; set; }
        [BindProperty] public int AccountId { get; set; }
        [BindProperty] public int Status {  get; set; }

        public StaffsModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task<IActionResult> OnGet()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId == 1 || roleId == 2)
            {
                Accounts = _accountService.GetAllStaffAccounts();
                ListNumber = Accounts.Count();
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }
        }

        public async Task<IActionResult> OnPost()
        {
            Accounts = _accountService.GetAllStaffAccounts();
            ListNumber = Accounts.Count();
            var account = _accountService.GetProfileAccount(AccountId);
            account.Status = Status;
            bool isChangeStatus = _accountService.UpdateProfileAccount(account);
            if (isChangeStatus)
            {
                return Page();
            }
            return RedirectToPage("/Error");
        }
    }
}
