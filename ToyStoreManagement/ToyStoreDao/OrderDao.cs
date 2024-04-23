using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace ToyStoreDao
{
    public class OrderDao : BaseToyStoreDao<Order>
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDao() { _dbContext = new ToyStoreDBContext(); }
        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            return _dbContext.Orders.AsQueryable().Include(c => c.Customer).Where(x => x.CustomerId == customerId).ToList();
        }

    }
}
