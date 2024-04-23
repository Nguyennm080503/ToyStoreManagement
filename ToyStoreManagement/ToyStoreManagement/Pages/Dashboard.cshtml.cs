using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IFeedbackService _feedbackService;

        public DashboardModel(IAccountService accountService, IProductService productService, IOrderService orderService, IFeedbackService feedbackService)
        {
            _accountService = accountService;
            _productService = productService;
            _orderService = orderService;
            _feedbackService = feedbackService;
        }
        public int CustomerNumber { get; set; }
        public int ProductNumber { get; set; }
        public int FeedbackNumber { get; set; }
        public decimal MoneyTotal { get; set; }
        public async Task<IActionResult> OnGet()
        {
            CustomerNumber = _accountService.GetAllCustomerAccounts().Count();

            return Page();
        }
    }
}
