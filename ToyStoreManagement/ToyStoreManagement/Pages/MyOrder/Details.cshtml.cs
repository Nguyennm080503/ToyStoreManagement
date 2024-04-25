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
using ToyStoreService.Implement;

namespace ToyStoreManagement.Pages.MyOrder
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailService detailService;
        private readonly IOrderService orderService;

        public DetailsModel(IOrderDetailService _detailService, IOrderService _orderService)
        {
            detailService = _detailService;
            orderService = _orderService;
        }

        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        public IList<OrderDetail> OrderDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            string accountid = HttpContext.Session.GetString("AccountId");

            if (accountid == null)
            {
                return RedirectToPage("/Login");
            }
            Order = orderService.GetOrder(id);
            OrderDetails = detailService.GetAllOrderDetail(id);
            return Page();
        }
    }
}
