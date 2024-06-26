using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Security.Claims;
using ToyStoreService.Interface;
using BusinessObjects;
using Microsoft.AspNetCore.Identity;

namespace ToyStoreManagement.Pages
{
    public class LoginByGoogleModel : PageModel
    {
        private readonly IAccountService _accountService;

		public string ReturnUrl { get; set; }

		public LoginByGoogleModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

		public async Task<IActionResult> OnPost()
		{
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Page("/LoginByGoogle")
            });
            return Page();
		}

		public async Task<IActionResult> OnGet()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (result.Succeeded)
            {
                string email = result.Principal.FindFirstValue(ClaimTypes.Email);
                var account = _accountService.GetAccountByEmail(email);

                if (account != null && account.Status == 1)
                {
                    HttpContext.Session.SetString("Name", account.Name);
                    HttpContext.Session.SetInt32("RoleId", (int)account.RoleId);
                    HttpContext.Session.SetInt32("AccountId", account.AccountId);
                    return RedirectToPage("/Index");
                }
                if (account != null && account.Status == 0)
                {
                    HttpContext.Session.SetString("Message", "Your email is blocked!");
                    return RedirectToPage("/Login");
                }
                else
                {
                    HttpContext.Session.SetString("Email", email);
                    return RedirectToPage("/Register");
                }
            }

            return RedirectToPage("/Error");
        }
    }
}
