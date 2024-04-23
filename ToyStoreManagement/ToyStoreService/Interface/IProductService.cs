using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProduct();
        public Product GetProductById(int id);
        bool UpdateQuantity(Product product);
    }
}
