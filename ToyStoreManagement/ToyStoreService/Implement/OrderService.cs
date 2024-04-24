using BusinessObjects.Models;
using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
<<<<<<< HEAD

        public IEnumerable<Order> GetAllOrder()
        {
            return _orderRepository.GetAllOrder();
        }

        public Order GetOrder(int id)
        {
            return _orderRepository.GetOrder(id);
=======
        public IEnumerable<Order> GetAllOrders() { return _orderRepository.GetAllOrders(); }
        public bool AddOrder(Order ord) { return _orderRepository.AddOrder(ord);}
        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            return _orderRepository.GetOrderByCustomerId(customerId);
>>>>>>> origin/tai_cart
        }
    }
}
