using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ToyStoreManagement.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToyStoreDBContext _context;

        public IndexModel(ToyStoreDBContext context)
        {
            _context = context;
        }

        public IList<Category> Categories { get; set; } = default!;
        public IList<Product> Products { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categories = await _context.Categories.ToListAsync();
            }

            if (_context.Products != null)
            {
                Products = await _context.Products.ToListAsync();
            }
        }
    }
}
