using BusinessObjects;
using BusinessObjects.Models;
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
        private readonly ICategoryService _categoryService;

        public DashboardModel(IAccountService accountService, IProductService productService, IOrderService orderService, IFeedbackService feedbackService, ICategoryService categoryService)
        {
            _accountService = accountService;
            _productService = productService;
            _orderService = orderService;
            _feedbackService = feedbackService;
            _categoryService = categoryService;
        }
        public int CustomerNumber { get; set; }
        public int ProductNumber { get; set; }
        public int FeedbackNumber { get; set; }
        public decimal MoneyTotal { get; set; }


        public IEnumerable<ProductCount> ProductCountEachCategory { get; set; }
        public IEnumerable<Order> TotalMoneyEachMonth { get; set; }
        public async Task<IActionResult> OnGet()
        {
            CustomerNumber = _accountService.GetAllCustomerAccounts().Count();
            ProductNumber = _productService.GetAllProducts().Count();
            MoneyTotal = (decimal)_orderService.GetAllOrder().Sum(x => x.TotalAmount);
            ProductCountEachCategory = _productService.GetAllProducts().GroupBy(x => x.CategoryId).Select(g => new ProductCount
            {
                CategoryName = _categoryService.GetAllCategory().Where(x => x.CategoryId == g.Key).FirstOrDefault().Name,
                TotalProduct = g.Count(),
            }).ToList();
            TotalMoneyEachMonth = _orderService.GetAllOrder().GroupBy(x => x.OrderDate.Value.Month).Select(g => new Order
            {
                OrderDate = new DateTime(1, g.Key, 1),
                TotalAmount = g.Sum(x => x.TotalAmount),
            }).ToList();
            FeedbackNumber = _feedbackService.GetAllFeedback().Count();
            return Page();
        }
    }
}
