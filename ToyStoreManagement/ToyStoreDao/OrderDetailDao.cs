using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace ToyStoreDao
{
    public class OrderDetailDao
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDetailDao() { _dbContext = new ToyStoreDBContext(); }
        public bool AddOrderDetails(IList<OrderDetail> orderDetails)
        {
            try
            {
                _dbContext.OrderDetails.AddRange(orderDetails);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public IEnumerable<OrderDetail> GetAllOrderDetail(int id)
        {
            return (IEnumerable<OrderDetail>)_dbContext.Orders.Where(x => x.OrderId == id).ToList();
        }
    }
}
