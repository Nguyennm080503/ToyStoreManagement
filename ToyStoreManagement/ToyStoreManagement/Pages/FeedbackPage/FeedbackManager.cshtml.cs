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

        public IEnumerable<Feedback> Feedback { get; set; } = default!;
        public IEnumerable<Product> Products { get; set; }
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        public int ListNumber { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var feedback = feedbackService.GetFeedbackByProductId(ProductId);
            if (feedback == null)
            {
                Feedback = new List<Feedback>();
                Message = "No feedback available for this product.";
            }
            Feedback = feedback;
            return Page();
        }
    }
}
