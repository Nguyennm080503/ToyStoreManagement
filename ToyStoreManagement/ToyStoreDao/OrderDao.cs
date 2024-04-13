using BusinessObjects.Models;

namespace ToyStoreDao
{
    public class OrderDao : BaseToyStoreDao<Order>
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }
    }
}
