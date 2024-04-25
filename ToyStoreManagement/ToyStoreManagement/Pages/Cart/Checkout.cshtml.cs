using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ToyStoreManagement.Pages.Toy;
using ToyStoreManagement.View_Models;
using ToyStoreService.Implement;
using ToyStoreService.Interface;

namespace ToyStoreManagement.Pages.Cart
{
    public class CheckoutModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService orderDetailService;
        private readonly IAccountService accountService;
        private readonly IProductService productService;
        public CheckoutModel (IOrderDetailService detailService, IOrderService orderService,IAccountService account, IProductService prodService)
        {
            orderDetailService = detailService;
            _orderService = orderService;
            accountService = account;
            productService = prodService;
        }
        public IList<CartItem> Cart { get; set; }

        //[Required(ErrorMessage = "Shipping address can not be empty")]
        //[StringLength(maximumLength: 50,
        //                MinimumLength = 6,
        //                ErrorMessage = "Shipping address's length must be between 6-50 characters")]
        [BindProperty]
        [Display(Name = "Shipping address")]
        public string ShippingAddress { get; set; }
        [BindProperty]
        public decimal TotalPrice { get; set; }
        public IActionResult OnGet()
        {
           var accountId = HttpContext.Session.GetInt32("AccountId");
            if (string.IsNullOrEmpty(accountId.ToString()))
            {
                return RedirectToPage("/Login");
            }

            List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
            if (cart != null)
            {
                TotalPrice = GetTotalPrice(cart);
                Cart = cart;
            }
            else
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        private decimal GetTotalPrice(List<CartItem> cart)
        {
            decimal result = 0;
            foreach (CartItem item in cart)
            {
                result += item.Price;
            }
            return result;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Account acc;
                var AccountId = HttpContext.Session.GetInt32("AccountId");
                if (string.IsNullOrEmpty(AccountId.ToString()))
                {
                    return RedirectToPage("/Login");
                }
                else
                {
                    acc = accountService.GetProfileAccount((int)AccountId);
                }


                List<CartItem> cart = HttpContext.Session.GetComplexData<List<CartItem>>("CART");
                if (!ModelState.IsValid)
                {

                    if (cart != null)
                    {
                        TotalPrice = GetTotalPrice(cart);
                        Cart = cart;
                    }
                    else
                    {
                        return RedirectToPage("./Index");
                    }
                    return Page();
                }

                string resultCheckProductQuantity = await ProcessCheckingQuantityAsync(cart);
                if (!string.IsNullOrEmpty(resultCheckProductQuantity))
                {
                    Cart = cart;
                    TotalPrice = GetTotalPrice(cart);
                    TempData["Message"] = resultCheckProductQuantity;
                    return Page();
                }

                Order order = new Order
                {
                    
                    CustomerId = acc.AccountId,
                    TotalAmount = TotalPrice,
                    OrderDate = DateTime.Now,
                    Address = ShippingAddress,
                    Status = 1,
                    
                };

                //Add order 
                _orderService.AddOrder(order);
                IList<OrderDetail> orderDetails = new List<OrderDetail>();
                foreach (CartItem cartItem in cart)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.Price / cartItem.Quantity,
                    };
                    orderDetails.Add(orderDetail);
                }
                if (orderDetails.Count > 0)
                {
                    //Add order details
                    orderDetailService.AddOrderDetails(orderDetails);
                }

                //Update product's quantity in stock
                UpdateProductQuantityStock(cart);

                //Delete cart after checkout
                HttpContext.Session.Remove("CART");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                return Page();
            }
            return RedirectToPage("/MyOrder/Index");
        }


        //--------------------------------------------------------------

        private async void UpdateProductQuantityStock(List<CartItem> cart)
        {
            foreach (CartItem cartItem in cart)
            {

                Product product = productService.GetProductById(cartItem.ProductId);
                product.StockQuantity -= cartItem.Quantity;


                try
                {
                    productService.UpdateQuantity(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
        }

        private async Task<string> ProcessCheckingQuantityAsync(List<CartItem> cart)
        {
            string result = "";
            foreach (CartItem cartItem in cart)
            {
                Product product = productService.GetProductById(cartItem.ProductId);
                if (product.StockQuantity < cartItem.Quantity)
                {
                    result = $"The product ${product.Name} does not have enough quantity in stock(${product.StockQuantity})";
                    break;
                }
            }
            return result;
        }
    }
}
