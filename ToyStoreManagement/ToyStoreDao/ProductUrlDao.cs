using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class ProductUrlDao : BaseToyStoreDao<Product>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductUrlDao() { _dbContext = new ToyStoreDBContext(); }
    }
}
