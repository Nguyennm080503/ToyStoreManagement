using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDao _orderDetailDao;

        public OrderDetailRepository()
        {
            _orderDetailDao = new OrderDetailDao();
        }
        public bool AddOrderDetails(IList<OrderDetail> orderDetails)
        {
            return _orderDetailDao.AddOrderDetails(orderDetails);
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail(int id)
        {
            return _orderDetailDao.GetAllOrderDetail(id);
        }
    }
}
