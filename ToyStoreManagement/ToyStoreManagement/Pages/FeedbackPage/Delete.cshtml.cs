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
    public class DeleteModel : PageModel
    {
        private readonly IFeedbackService feedbackService;

        public DeleteModel(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

      [BindProperty]
      public Feedback Feedback { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null || feedbackService.GetAllFeedback() == null)
            {
                return NotFound();
            }
            try
            {
                bool check = feedbackService.DeleteFeedback(id);
                if (check)
                {
                    return RedirectToPage("/Feedback");
                }
                else
                {
                    return RedirectToPage("/Error");
                }
            }
            catch(Exception ex)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
