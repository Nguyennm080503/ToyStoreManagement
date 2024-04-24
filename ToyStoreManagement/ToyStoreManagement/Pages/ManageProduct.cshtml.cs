using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToyStoreService.Implement;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class ManageProductModel : PageModel
    {
        private readonly IProductService _productService;
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
        public int ListNumber { get; set; }
        [BindProperty] public int ProductId { get; set; }
        [BindProperty] public int Status { get; set; }
        public ManageProductModel(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> OnGet()
        {
            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId == 1 || roleId == 2)
            {
                Products = _productService.GetAllProducts().OrderByDescending(x => x.ProductId);
                ListNumber = Products.Count();
                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }
        }
        public async Task<IActionResult> OnPost()
        {
            Products = _productService.GetAllProducts().OrderByDescending(x => x.ProductId);
            ListNumber = Products.Count();
            var product = _productService.GetProductById(ProductId);
            product.Status = Status;
            _productService.UpdateProduct(product);
            return Page();
        }
    }
}
