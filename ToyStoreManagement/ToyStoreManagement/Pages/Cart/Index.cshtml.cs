using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToyStoreManagement.Pages.Toy;
using ToyStoreManagement.View_Models;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;
        public IndexModel(IProductService service)
        {
            productService = service;
        }
        public IList<CartItem> Cart { get; set; }


        public IActionResult OnGet()
        {
            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
            if (cart != null)
            {
                Cart = cart;
            }
            return Page();
        }

        public async Task<IActionResult> OnGetIncreaseAsync(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
            if (cart == null)
            {
                return RedirectToPage();
            }

            CartItem cartItem = cart.FirstOrDefault(i => i.ProductId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            Product product =  productService.GetProductById(id);
                
            if (product.StockQuantity == 0 || product.StockQuantity < cartItem.Quantity + 1)
            {
                TempData["Message"] = "This product is not enough in stock.";
            }
            else
            {
                cartItem.Quantity += 1;
                cartItem.Price += (decimal)product.Price;
                HttpContext.Session.SetComplexData("CART", cart);
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnGetDecreaseAsync(int id)
        {

            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
            if (cart == null)
            {
                return RedirectToPage();
            }

            CartItem cartItem = cart.FirstOrDefault(i => i.ProductId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            Product product = productService.GetProductById(id);
            if (cartItem.Quantity - 1 == 0)
            {
                OnPostRemove(id);
            }
            else
            {
                cartItem.Quantity -= 1;
                cartItem.Price -= (decimal)product.Price;
                HttpContext.Session.SetComplexData("CART", cart);
            }
            return RedirectToPage();
        }

        public IActionResult OnPostRemove(int productId)
        {

            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
            if (cart != null)
            {
                if (cart.Exists(i => i.ProductId == productId))
                {
                    CartItem item = cart.FirstOrDefault(i => i.ProductId == productId);
                    cart.Remove(item);
                    if (cart.Count > 0)
                    {
                        HttpContext.Session.SetComplexData("CART", cart);
                    }
                    else
                    {
                        HttpContext.Session.Remove("CART");
                    }
                }
            }
            return RedirectToPage();
        }
    }
}

