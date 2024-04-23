using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IOrderRepository
    {
        public IEnumerable<Order> GetAllOrders();
        bool AddOrder(Order ord);
        IEnumerable<Order> GetOrderByCustomerId(int customerId);
    }
}
