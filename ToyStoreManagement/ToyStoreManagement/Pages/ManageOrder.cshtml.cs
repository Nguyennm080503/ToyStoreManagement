using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Implement;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class ManageOrderModel : PageModel
    {
        private readonly IOrderService _orderService;

        public ManageOrderModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

		public IEnumerable<Order> Orders { get; set; }
		public int ListNumber { get; set; }

		public async Task<IActionResult> OnGet()
        {
			var roleId = HttpContext.Session.GetInt32("RoleId");
			if (roleId == 1 || roleId == 2)
			{
				Orders = _orderService.GetAllOrder().OrderByDescending(x => x.OrderId);
				ListNumber = Orders.Count();
				return Page();
			}
			else
			{
				return RedirectToPage("/Login");
			}
		}
    }
}
