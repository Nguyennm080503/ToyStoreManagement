using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IOrderService
    {
        public IEnumerable<Order> GetAllOrders();
        bool AddOrder(Order ord);

        IEnumerable<Order> GetOrderByCustomerId(int customerId);
    }
}
