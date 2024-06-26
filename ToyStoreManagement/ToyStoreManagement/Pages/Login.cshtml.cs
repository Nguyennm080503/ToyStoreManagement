using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using ToyStoreService.Interface;
using Microsoft.AspNetCore.Identity;
using System.Net.WebSockets;

namespace ToyStoreManagement.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [BindProperty] public string UserName { get; set; }
        [BindProperty] public string Password { get; set; }
        [BindProperty] public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync() 
        {
            if(UserName == null && Password == null)
            {
                Message = "Username and Password are require!";
                return Page();
            }
            else
            {
                var account = _accountService.GetAccountByUsername(UserName);
                if (account == null)
                {
					Message = "Username is not existed!";
					return Page();
				}
                else if (account != null && account.Password != Password)
                {
					Message = "Password is wrong!";
					return Page();
				}
                else if (account != null && account.Password == Password && account.Status == 0)
                {
					Message = "Your account is blocked!";
					return Page();
				}
                {
                    HttpContext.Session.SetString("Name", account.Name);
                    HttpContext.Session.SetInt32("RoleId", (int)account.RoleId);
                    HttpContext.Session.SetInt32("AccountId", account.AccountId);
                    return RedirectToPage("/Dashboard");

                }
            }
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var message = HttpContext.Session.GetString("Message");
            if(message != null)
            {
                Message = message;
                HttpContext.Session.Remove("Message");
                return Page();
            }
            return Page();
        }
	}
}
