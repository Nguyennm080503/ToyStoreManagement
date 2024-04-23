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
    public class FeedbackModel : PageModel
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackModel(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public IList<Feedback> Feedback { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (feedbackService.GetAllFeedback() != null)
            {
                Feedback = (IList<Feedback>)feedbackService.GetAllFeedback();
            }
        }
    }
}
