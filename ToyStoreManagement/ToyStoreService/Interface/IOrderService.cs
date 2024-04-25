using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrder();
        Order GetOrder(int id);
        bool AddOrder(Order ord);
        IEnumerable<Order> GetOrderByCustomerId(int customerId);
        bool UpdateOrder(Order ord);
    }
}
