using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class ProductUrlDao : BaseToyStoreDao<Product>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductUrlDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }
    }
}
