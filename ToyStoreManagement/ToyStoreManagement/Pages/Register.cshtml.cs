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
                Message = "All fields must be required!";
                return Page();
            }
            else if(!ValidateEmail(Email))
            {
				Message = "Email is invalid! Fill email again.";
				return Page();
			}
            else if (!ValidatePhoneNumber(Phone))
            {
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
                    return RedirectToPage("/Index");

				}
                else
                {
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
