using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.MyOrder
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailService detailService;

        public DetailsModel(IOrderDetailService _detailService)
        {
            detailService = _detailService;
        }

        public IList<OrderDetail> OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string role = HttpContext.Session.GetString("ROLE");
            if (string.IsNullOrEmpty(role))
            {
                return RedirectToPage("/Error");
            }

            if (id == null)
            {
                return NotFound();
            }
            OrderDetail = detailService.GetAllOrderDetail(id).ToList();

            return Page();
        }
    }
}
