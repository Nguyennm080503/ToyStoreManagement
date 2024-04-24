using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;
using ToyStoreRepository.Interface;

namespace ToyStoreManagement.Pages.MyOrder
{
    public class IndexModel : PageModel
    {
        private readonly IOrderDetailRepository _repo;

        public IndexModel(IOrderDetailRepository repo)
        {
            _repo = repo;
        }

        public string search;

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
            OrderDetail = _repo.GetAllOrderDetail(id).ToList();

            return Page();
        }
    }
}
