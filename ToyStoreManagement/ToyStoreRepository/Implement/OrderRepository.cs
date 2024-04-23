using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDao _orderDao;
        public OrderRepository() { _orderDao = new OrderDao(); }
        public IEnumerable<Order> GetAllOrder()
        {
            return _orderDao.GetAll();
        }

        public Order GetOrder(int id)
        {
            return _orderDao.GetDetail(id);
        }
    }
}
