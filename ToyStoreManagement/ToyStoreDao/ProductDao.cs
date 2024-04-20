using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class ProductDao : BaseToyStoreDao<Product>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductDao() { _dbContext = new ToyStoreDBContext(); }
    }
}
