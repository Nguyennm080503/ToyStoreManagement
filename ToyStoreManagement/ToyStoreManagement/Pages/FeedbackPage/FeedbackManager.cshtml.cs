using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Implement;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.FeedbackPage
{
    public class FeedbackManagerModel : PageModel
    {
        private readonly IFeedbackService feedbackService;
        public FeedbackManagerModel(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public IList<Feedback> Feedback { get; set; } = default!;
        public IEnumerable<Product> Products { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        public int ListNumber { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if (feedbackService.GetAllFeedback() != null)
            {
                Feedback = feedbackService.GetAllFeedback().OrderByDescending(x => x.ProductId).ToList();
                ListNumber = Feedback.Count();
                return Page();
            }
            else
            {
                return RedirectToPage("/Feedback");
            }
        }
    }
}
