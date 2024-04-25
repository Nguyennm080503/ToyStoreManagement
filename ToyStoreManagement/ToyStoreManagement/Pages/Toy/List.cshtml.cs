using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ToyStoreManagement.View_Models;
using ToyStoreService.Implement;
using ToyStoreService.Interface;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace ToyStoreManagement.Pages.Toy
{
    public class ListModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ListModel(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public string Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string Category { get; set; }
        public IList<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public async Task OnGetAsync(string? keyword, decimal? minPrice, decimal? maxPrice, string? category)
        {
            Categories = _categoryService.GetAllCategory();
            Keyword = keyword;
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            Category = category;

            if (!string.IsNullOrEmpty(Keyword) || MinPrice.HasValue || MaxPrice.HasValue || !string.IsNullOrEmpty(Category))
            {
                Products = _productService.SearchProducts(Keyword, MinPrice, MaxPrice, Category);
            }
            else
            {
                Products = _productService.GetAllProductsHome();
            }
        }
        public async Task<IActionResult> OnPostAddToCartAsync([FromForm] int productId)
        {
            Product product = _productService.GetProductById(productId);
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