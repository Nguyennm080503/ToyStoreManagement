using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProduct();
        public Product GetProductById(int id);
        bool UpdateQuantity (Product product);
        
    }
}
