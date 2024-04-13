using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class ProductDao : BaseToyStoreDao<Product>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }
    }
}
