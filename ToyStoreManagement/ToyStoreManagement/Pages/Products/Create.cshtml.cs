using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        public string Message { get; set; }

        public IEnumerable<Category> Categories {  get; set; }    

        public CreateModel(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> OnGet()
        {

            var roleId = HttpContext.Session.GetInt32("RoleId");
            if (roleId == 1 || roleId == 2)
            {
                Categories = _categoryService.GetAllCategory();

                return Page();
            }
            else
            {
                return RedirectToPage("/Login");
            }
        }

		[BindProperty] public string Name { get; set; }
		[BindProperty] public int Price { get; set; }
		[BindProperty] public int StockQuantity { get; set; }
		[BindProperty] public int CategoryId { get; set; }
		[BindProperty] public string Description { get; set; }
		[BindProperty] public string Thumbnail { get; set; }


		// To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
		public async Task<IActionResult> OnPostAsync()
        {
            if(_service.GetAllProducts().Any(x => x.Name == Name))
            {
                Message = "Product is existed! Try again";
                return Page();
            }
            else
            {
                Product product = new Product();
                product.Name = Name;
                product.Price = Price;
                product.CategoryId = CategoryId;
                product.Description = Description;
                product.StockQuantity = StockQuantity;
                product.PhotoUrlThumnail = Thumbnail;
                product.Status = 1;
                _service.AddProduct(product);
                return RedirectToPage("/ManagementProduct");
            }
        }
    }
}
