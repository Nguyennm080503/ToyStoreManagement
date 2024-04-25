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
        private readonly IFeedbackService _feedbackService;
        private readonly ICategoryService _categoryService;


        [BindProperty(SupportsGet = true)]
        public int ProductId { get; set; }
        public string Message { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public DetailsModel(IProductService service, ICategoryService categoryService, IFeedbackService feedbackService)
        {
            _service = service;
            _categoryService = categoryService;
            _feedbackService = feedbackService;
        }

        public Product Product { get; set; } = default!;
        public IEnumerable<Feedback> Feedback { get; set; }

        [BindProperty]
        public int productId { get; set; }

        [BindProperty]
        public string FeedbackText { get; set; }
        [BindProperty]
        public DateTime FeedbackDate { get; set; }

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

            var feedback = _feedbackService.GetFeedbackByProductId((int)id);

            if (feedback == null)
            {
                Feedback = new List<Feedback>();
                Message = "No feedback available for this product.";
            }
            Feedback = feedback;
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

            return RedirectToPage("./Details", new { id = productId });
        }

        public async Task<IActionResult> OnPostAddFeedbackAsync()
        {
            var accountid = HttpContext.Session.GetInt32("AccountId");
            Feedback feedback = new Feedback();
            feedback.CustomerId = accountid;
            feedback.ProductId = productId;
            feedback.FeedbackText = FeedbackText;
            feedback.FeedbackDate = DateTime.Now;
            try
            {
                bool check = false;
                check = _feedbackService.CreateFeedback(feedback);
                if (check)
                {
                    return RedirectToPage("./Details", new { id = productId });
                }
                else
                {
                    return RedirectToPage("Error");
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return RedirectToPage("Error");
            }
        }
    }
}