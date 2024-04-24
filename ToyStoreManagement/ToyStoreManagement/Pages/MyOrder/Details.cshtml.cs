using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreRepository.Interface;

namespace ToyStoreManagement.Pages.MyOrder
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _repo;

        public DetailsModel(IOrderRepository repo)
        {
            _repo = repo;
        }

        public IList<Order> Order { get; set; } = default!;

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
            Order = _repo.GetAllOrder(id).ToList();

            return Page();
        }
    }
}
