using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using ToyStoreService.Interface;
using ToyStoreManagement.View_Models;
using ToyStoreService.Implement;
using Newtonsoft.Json;

namespace ToyStoreManagement.Pages.Toy
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
        public async Task<IActionResult> OnPostAddToCartAsync([FromForm] int productId)
        {
            Product product = _service.GetProductById(productId);
            //Check validation for product
            if (product == null)
            {
                return NotFound();
            }

            if (product.StockQuantity == 0)
            {
                ViewData["Messsage"] = "This product is not enough in stock.";
                return RedirectToPage();
            }

            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
            CartItem item = new CartItem
            {
                ProductId = product.ProductId,
                ProductName = product.Name,
                Price = (decimal)product.Price,
                Quantity = 1,
            };
            if (cart != null)
            {
                if (cart.Exists(i => i.ProductId == product.ProductId))
                {
                    // If item is already exist in cart
                    int index = cart.FindIndex(i => i.ProductId == product.ProductId);
                    if (product.StockQuantity < cart[index].Quantity + 1)
                    {
                        TempData["Message"] = "The product is not enough in stock";
                    }
                    else
                    {
                        cart[index].Quantity += 1;
                        cart[index].Price += (decimal)product.Price;
                        TempData["Message"] = "Add product to cart successfully";
                    }
                }
                else
                {
                    cart.Add(item);
                    TempData["Message"] = "Add product to cart successfully";
                }
                HttpContext.Session.SetComplexData("CART", cart);
            }
            else //When cart is null -> create new cart
            {
                List<CartItem> list = new List<CartItem>();
                list.Add(item);
                HttpContext.Session.SetComplexData("CART", list);
                TempData["Message"] = "Add product to cart successfully";
            }

            return RedirectToPage("./Details", new {id = productId });
        }
    }
}