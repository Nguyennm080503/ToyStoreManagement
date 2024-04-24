using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IOrderDetailService
    {
        bool AddOrderDetails(IList<OrderDetail> orderDetails);

        public IEnumerable<OrderDetail> GetAllOrderDetail(int id);
    }
}
