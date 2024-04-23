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
        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }
        
    }
}
