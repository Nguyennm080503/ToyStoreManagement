using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;
using System.Xml.Linq;
using ToyStoreService.Implement;

namespace ToyStoreManagement.Pages.FeedbackPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedbackService feedbackService;
        private readonly IAccountService accountService;
        private readonly IProductService productService;

        public DetailsModel(IFeedbackService feedbackService, IProductService productService, IAccountService accountService)
        {
            this.feedbackService = feedbackService;
            this.productService = productService;
            this.accountService = accountService;
        }
        [BindProperty(SupportsGet = true)]
        public int FeedbackId { get; set; }
        public Feedback Feedback { get; set; } = default!; 
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var feedback = feedbackService.GetFeedbackById((int)FeedbackId);
            Accounts = accountService.GetAllAccounts();
            Products = productService.GetAllProducts();
            if (feedback == null)
            {
                return NotFound();
            }
            else 
            {
                Feedback = feedback;
            }
            return Page();
        }
        [BindProperty] public int CustomerId { get; set; }
        [BindProperty] public int ProductId { get; set; }
        [BindProperty] public string FeedbackText { get; set; }
        [BindProperty] public DateTime FeedbackDate { get; set; }
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (feedbackService.GetAllFeedback() == null)
            {
                Message = "Feedback is existed! Try again";
                return Page();
            }
            else
            {
                Accounts = accountService.GetAllAccounts();
                Products = productService.GetAllProducts();
                var feedback = feedbackService.GetFeedbackById(FeedbackId);
                feedback.FeedbackText = FeedbackText;
                feedback.FeedbackDate = FeedbackDate;
                feedback.CustomerId = CustomerId;
                feedback.ProductId = ProductId;
                feedbackService.UpdateFeedback(feedback);
                Feedback = feedback;
                return RedirectToPage("/FeedbackPage/Feedback");
            }
        }
    }
}
