using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.Products
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;

		[BindProperty(SupportsGet = true)]
		public int ProductId { get; set; }
        public string Message { get; set; }
		public IEnumerable<Category> Categories { get; set; }

		public DetailsModel(IProductService service, ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }

        public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync()
        {
            var product = _service.GetProductById((int)ProductId);
            Categories = _categoryService.GetAllCategory();
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

		[BindProperty] public int Id { get; set; }
		[BindProperty] public string Name { get; set; }
		[BindProperty] public int Price { get; set; }
		[BindProperty] public int StockQuantity { get; set; }
		[BindProperty] public int CategoryId { get; set; }
		[BindProperty] public string Description { get; set; }


		public async Task<IActionResult> OnPostAsync()
		{
			if (_service.GetAllProducts().Any(x => x.Name == Name))
			{
				Message = "Product is existed! Try again";
				return Page();
			}
			else
			{
                Categories = _categoryService.GetAllCategory();
                var product = _service.GetProductById(Id);
				product.Name = Name;
				product.Price = Price;
				product.CategoryId = CategoryId;
				product.Description = Description;
				product.StockQuantity = StockQuantity;
				product.Status = 1;
				_service.UpdateProduct(product);
                Product = product;
				return RedirectToPage("/ManageProduct");
			}
		}
	}
}
