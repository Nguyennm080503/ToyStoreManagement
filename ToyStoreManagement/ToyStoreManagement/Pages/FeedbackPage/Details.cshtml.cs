using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.FeedbackPage
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedbackService feedbackService;

        public DetailsModel(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public Feedback Feedback { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || feedbackService.GetAllFeedback() == null)
            {
                return NotFound();
            }

            var feedback = feedbackService.GetFeedbackById(id);
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
    }
}
