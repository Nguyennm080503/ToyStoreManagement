using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDao _orderDao;
<<<<<<< HEAD
        public OrderRepository() { _orderDao = new OrderDao(); }
        public IEnumerable<Order> GetAllOrder()
        {
            return _orderDao.GetAll();
        }

        public Order GetOrder(int id)
        {
            return _orderDao.GetDetail(id);
=======

        public OrderRepository()
        {
            _orderDao = new OrderDao();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderDao.GetAll();
        }
        public bool AddOrder(Order ord)
        {
            return _orderDao.Create(ord);
        }
        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            return _orderDao.GetOrderByCustomerId(customerId);
>>>>>>> origin/tai_cart
        }
    }
}
