using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class OrderDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }

        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        public OrderDetailModel(IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
        }

        public async Task<IActionResult> OnGet()
        {
            Order = _orderService.GetOrder(OrderId);
            OrderDetails = _orderDetailService.GetAllOrderDetail(OrderId);
            return Page();
        }
    }
}
