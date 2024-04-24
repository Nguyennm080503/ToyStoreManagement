
using BusinessObjects.Models;
using ToyStoreDao;
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
        public void AddProduct(Product product) => _productRepository.AddProduct(product);
        public Product GetProductById(int productId) => _productRepository.GetProductById(productId);
        public void UpdateProduct(Product updatedProduct) => _productRepository.UpdateProduct(updatedProduct);
        public void DeleteProduct(int productId) => _productRepository.DeleteProduct(productId);
        public List<Product> GetAllProducts() => _productRepository.GetAllProducts();
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category) => _productRepository.SearchProducts(name, minPrice, maxPrice, category);
    }
}
