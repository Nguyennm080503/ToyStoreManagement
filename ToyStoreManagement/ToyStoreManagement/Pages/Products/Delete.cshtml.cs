using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductService _service;

        public DeleteModel(IProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _service.GetAllProducts == null)
            {
                return NotFound();
            }

            var product = _service.GetProductById((int)id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _service.GetAllProducts == null)
            {
                return NotFound();
            }
            var product = _service.GetProductById((int)id);

            if (product != null)
            {
                Product = product;
                _service.DeleteProduct(Product.ProductId);
            }

            return RedirectToPage("./Index");
        }
    }
}
