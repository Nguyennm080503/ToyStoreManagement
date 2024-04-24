using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IOrderService
    {
<<<<<<< HEAD
        IEnumerable<Order> GetAllOrder();
        Order GetOrder(int id);
=======
        public IEnumerable<Order> GetAllOrders();
        bool AddOrder(Order ord);

        IEnumerable<Order> GetOrderByCustomerId(int customerId);
>>>>>>> origin/tai_cart
    }
}
