using BusinessObjects.Models;


namespace ToyStoreDao
{
    internal class OrderDetailDao
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDetailDao() { _dbContext = new ToyStoreDBContext(); }
    }
}
