using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly IProductService _service;

        public EditModel(IProductService service)
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
            Product = product;
            ViewData["CategoryId"] = new SelectList(_service.GetAllProducts(), "CategoryId", "CategoryId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           // _context.Attach(Product).State = EntityState.Modified;

            try
            {
                _service.UpdateProduct(Product);
           //     await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductExists(int id)
        {
            if (_service.GetProductById(id)!=null)
            {
                return true;
            }
            return false;              
        }
    }
}
