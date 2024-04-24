using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IOrderDetailService
    {
        bool AddOrderDetails(IList<OrderDetail> orderDetails);
    }
}
