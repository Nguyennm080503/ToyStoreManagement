using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class CreateStaffModel : PageModel
    {
        private readonly IAccountService _accountService;
		[BindProperty] public string Email { get; set; }
		[BindProperty] public string Name { get; set; }
		[BindProperty] public string Phone { get; set; }
		[BindProperty] public string Address { get; set; }
		[BindProperty] public string Username { get; set; }
		[BindProperty] public string Password { get; set; }
		[BindProperty] public string Message { get; set; }

		public CreateStaffModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
		public async Task<IActionResult> OnPost()
		{
			if (Email == null || Name == null || Phone == null || Address == null)
			{
				Message = "All fields must be required!";
				return Page();
			}
			else if (!ValidateEmail(Email))
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
					Username = Username,
					Password = Password,
					Email = Email,
					Name = Name,
					Phone = Phone,
					Address = Address,
					RoleId = 2,
					Status = 1,
				};
				bool isRegister = _accountService.RegisterNewAccount(account);
				if (isRegister)
				{
					return RedirectToPage("/Staffs");

				}
				else
				{
					Message = "Have some error with service. Try again!";
					return Page();
				}
			}
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
