using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrder();
    }
}
