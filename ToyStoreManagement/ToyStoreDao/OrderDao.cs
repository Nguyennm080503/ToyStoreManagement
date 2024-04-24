using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace ToyStoreDao
{
    public class OrderDao : BaseToyStoreDao<Order>
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDao() { _dbContext = new ToyStoreDBContext(); }
<<<<<<< HEAD

        public override IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders.Include(x => x.Customer).ToList();
        }
        public override Order GetDetail(int id)
        {
            return _dbContext.Orders.Include(x => x.Customer).Where(x => x.OrderId == id).FirstOrDefault();
        }
=======
        public IEnumerable<Order> GetOrderByCustomerId(int customerId)
        {
            return _dbContext.Orders.AsQueryable().Include(c => c.Customer).Where(x => x.CustomerId == customerId).ToList();
        }

>>>>>>> origin/tai_cart
    }
}
