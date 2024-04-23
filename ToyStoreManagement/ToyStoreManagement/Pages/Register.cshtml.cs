using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService;
		
		public RegisterModel(IAccountService accountService) 
		{ 
			_accountService = accountService;
		}

        [BindProperty] public string Email { get; set; }
        [BindProperty] public string Name { get; set; }
        [BindProperty] public string Phone {  get; set; }
        [BindProperty] public string Address { get; set; }
        [BindProperty] public string Message { get; set; }


		public string ErrorMessage { get; set; }
		public string EmailResponse { get; set; }

		[BindProperty]


		public string ReturnUrl { get; set; }

		public async Task<IActionResult> OnPost()
        {
            if(Email == null || Name == null || Phone == null || Address == null)
            {
                EmailResponse = Email;
				Message = "All fields must be required!";
                return Page();
            }
            else if(!ValidateEmail(Email))
            {
				EmailResponse = Email;
				Message = "Email is invalid! Fill email again.";
				return Page();
			}
            else if (!ValidatePhoneNumber(Phone))
            {
				EmailResponse = Email;
				Message = "Email is invalid! Fill email again.";
				return Page();
			}
            else
            {
                Account account = new Account
                {
                    Email = Email,
                    Name = Name,
                    Phone = Phone,
                    Address = Address,
                    RoleId = 3,
                    Status = 1,
                };
                bool isRegister = _accountService.RegisterNewAccount(account);
                if (isRegister)
                {
                    var accountuser = _accountService.GetAccountByEmail(Email);
                    if(accountuser != null)
                    {
                        HttpContext.Session.SetString("Name", accountuser.Name);
                        HttpContext.Session.SetInt32("AccountId", accountuser.AccountId);
                        HttpContext.Session.SetInt32("RoleId", (int)accountuser.RoleId);
                    }
                    return RedirectToPage("/Index");

				}
                else
                {
					EmailResponse = Email;
					Message = "Have some error with service. Try again!";
                    return Page();
                }
            }
        }
        public async Task<IActionResult> OnGet()
        {
            EmailResponse = HttpContext.Session.GetString("Email");
            return Page();
        }


		private bool ValidatePhoneNumber(string phoneNumber)
		{
			if (phoneNumber.Length != 12)
				return false;
			return true;
		}

		private bool ValidateEmail(string email)
		{
			string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
			Regex regex = new Regex(emailPattern);
			return regex.IsMatch(email);
		}
	}
}
