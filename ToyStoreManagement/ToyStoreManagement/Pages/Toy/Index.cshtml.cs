using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using ToyStoreService.Interface;
using ToyStoreManagement.View_Models;
using Newtonsoft.Json;

namespace ToyStoreManagement.Pages.Toy
{
    public class IndexModel : PageModel
    {
        private readonly IProductService productService;

        public IndexModel(IProductService service)
        {
            productService = service;
        }

        public IList<Product> Product { get; set; } = default!;

        public async Task OnGetAsync()
        {

            Product = (IList<Product>)productService.GetAllProducts();
        }
        public async Task<IActionResult> OnPostAddToCartAsync([FromForm] int productId)
        {
            Product product = productService.GetProductById(productId);
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

            return RedirectToPage();
        }
    }
    #region ExtendSession
    public static class SessionExtensions
    {
        public static T GetComplexData<T>(this ISession session, string key)
        {
            string data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static void SetComplexData(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
    }
}

#endregion

