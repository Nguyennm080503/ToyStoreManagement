using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.MyOrder
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService orderService;

        public IndexModel(IOrderService order)
        {
            orderService = order;
        }

        public IList<Order> Order { get;set; } = default!;
        public async Task OnGetAsync()
        {
            var id = HttpContext.Session.GetInt32("AccountId");
           Order = (IList<Order>)orderService.GetOrderByCustomerId((int)id);
        }
    }
}
