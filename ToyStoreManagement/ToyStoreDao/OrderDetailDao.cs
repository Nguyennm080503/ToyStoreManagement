using BusinessObjects.Models;


namespace ToyStoreDao
{
    internal class OrderDetailDao
    {
        private readonly ToyStoreDBContext _dbContext;
        public OrderDetailDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }
    }
}
