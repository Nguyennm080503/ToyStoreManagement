using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDao productDao;

        public ProductRepository()
        {
            productDao = new ProductDao();
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return productDao.GetAllProduct();
        }
        public Product GetProductById(int id)
        {
            return productDao.GetProductById(id);
        }
        public bool UpdateQuantity(Product product)
        {
            return productDao.Update(product);
        }
    }
}
