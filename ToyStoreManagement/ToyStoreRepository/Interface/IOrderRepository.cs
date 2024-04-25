using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
        Order GetOrder(int id);
        bool AddOrder(Order ord);
        IEnumerable<Order> GetOrderByCustomerId(int customerId);
        bool UpdateOrder(Order ord);
    }
}
