using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.FeedbackPage
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackService feedbackService;
        private readonly IAccountService accountService;
        private readonly IProductService productService;
        public CreateModel(IFeedbackService feedbackService, IAccountService accountService, IProductService productService)
        {
            this.feedbackService = feedbackService;
            this.accountService = accountService;
            this.productService = productService;
        }

        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public string FeedbackText { get; set; }
        [BindProperty]
        public DateTime FeedbackDate { get; set; }
        [BindProperty]
        public Feedback Feedback { get; set; } = default!;
        public string Message {  get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Account> Accounts {get; set; }

        public IActionResult OnGet()
        {
            try
            {
                var roleId = HttpContext.Session.GetInt32("RoleId");
                if (Accounts == null && Products == null && roleId == 3)
                {
                    Feedback = new Feedback();
                    Products = productService.GetAllProducts().ToList();
                    Accounts = accountService.GetAllAccounts().ToList();
                }
                else
                {
                    return Page();
                }
                return Page();
            }
            catch (Exception ex)
            {
                // Handle the exception
                Message = ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            var accountid = HttpContext.Session.GetInt32("AccountId");
            Feedback feedback = new Feedback();
            feedback.CustomerId = accountid;
            feedback.ProductId = ProductId;
            feedback.FeedbackText = FeedbackText;
            feedback.FeedbackDate = DateTime.Now;
            try
            {
                bool check = false;
                check = feedbackService.CreateFeedback(feedback);
                if (check)
                {
                    return RedirectToPage("/FeedbackPage/Feedback");
                }
                else
                {
                    Accounts = accountService.GetAllAccounts();
                    Products = productService.GetAllProducts();
                    Message = "";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Accounts = accountService.GetAllAccounts();
                Products = productService.GetAllProducts();
                Message = ex.Message;
                return Page();
            }
        }
    }
}
