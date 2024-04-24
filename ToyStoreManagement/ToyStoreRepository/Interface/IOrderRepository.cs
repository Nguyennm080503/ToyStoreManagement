using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IOrderRepository
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
