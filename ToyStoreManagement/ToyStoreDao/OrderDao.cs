using BusinessObjects.Models;

namespace ToyStoreDao
{
    public class OrderDao : BaseToyStoreDao<Order>
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDao() { _dbContext = new ToyStoreDBContext(); }
    }
}
