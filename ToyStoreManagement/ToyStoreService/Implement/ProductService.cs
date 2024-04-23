using BusinessObjects.Models;
using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _productRepository.GetAllProduct();
        }
        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public bool UpdateQuantity(Product product)
        {
            return _productRepository.UpdateQuantity(product);
        }
    }
}
