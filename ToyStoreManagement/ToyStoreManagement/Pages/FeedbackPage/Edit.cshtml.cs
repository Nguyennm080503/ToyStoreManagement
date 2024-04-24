using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.FeedbackPage
{
    public class EditModel : PageModel
    {
        private readonly IFeedbackService feedbackService;
        private readonly IAccountService accountService;
        private readonly IProductService productService;
        public EditModel(IFeedbackService feedbackService, IAccountService accountService, IProductService productService)
        {
            this.feedbackService = feedbackService;
            this.accountService = accountService;
            this.productService = productService;
        }
        [BindProperty]
        public int FeedbackId { get; set; }
        [BindProperty]
        public int AccountId { get; set; }
        [BindProperty]
        public int ProductId { get; set; }
        [BindProperty]
        public string FeedbackText { get; set; }
        [BindProperty]
        public DateTime FeedbackDate { get; set; }
        [BindProperty]
        public Feedback Feedback { get; set; } = default!;
        public string Message { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Account> Accounts { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            if (feedbackService.GetAllFeedback() == null)
            {
                return NotFound();
            }

            var feedback = feedbackService.GetFeedbackById(id);
            if (feedback == null)
            {
                return NotFound();
            }
            Feedback = feedback;
            Products = productService.GetAllProduct().ToList();
            Accounts = accountService.GetAllAccounts().ToList();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            Feedback feedback = new Feedback();
            feedback.CustomerId = AccountId;
            feedback.ProductId = ProductId;
            feedback.FeedbackText = FeedbackText;
            feedback.FeedbackDate = DateTime.Now;
            try
            {
                bool check = false;
                if (ModelState.IsValid)
                {
                    check = feedbackService.UpdateFeedback(feedback);
                }
                if (check)
                {
                    return RedirectToPage("/Feedback");
                }
                else
                {
                    Accounts = accountService.GetAllAccounts();
                    Products = productService.GetAllProduct();
                    Message = "";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                Accounts = accountService.GetAllAccounts();
                Products = productService.GetAllProduct();
                Message = ex.Message;
                return Page();
            }
        }

    }
}
