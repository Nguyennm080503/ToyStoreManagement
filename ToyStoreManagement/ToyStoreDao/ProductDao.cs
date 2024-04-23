using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class ProductDao : BaseToyStoreDao<Product>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductDao() { _dbContext = new ToyStoreDBContext(); }
        public IEnumerable<Product> GetAllProduct()
        {
            return _dbContext.Products.ToList();
        }
    }
}
