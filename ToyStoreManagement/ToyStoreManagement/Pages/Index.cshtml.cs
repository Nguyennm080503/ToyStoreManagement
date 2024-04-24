using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.ToyStoreDBContext _productService;

        //private readonly IProductService _productService;
        public int ListNumber { get; set; }
        //public IndexModel(IProductService productService)
        //{
        //    _productService = productService;
        //}
        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_productService.Products != null)
            {
                Products = await _productService.Products
                .Include(f => f.Category)
                .Include(f => f.ProductUrls).ToListAsync();
            }
        }
    }
}
