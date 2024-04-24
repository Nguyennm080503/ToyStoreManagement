using BusinessObjects.Models;
<<<<<<< HEAD
using ToyStoreDao;
=======
>>>>>>> origin/tai_cart
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
<<<<<<< HEAD
        public void AddProduct(Product product) => _productRepository.AddProduct(product);
        public Product GetProductById(int productId) => _productRepository.GetProductById(productId);
        public void UpdateProduct(Product updatedProduct) => _productRepository.UpdateProduct(updatedProduct);
        public void DeleteProduct(int productId) => _productRepository.DeleteProduct(productId);
        public List<Product> GetAllProducts() => _productRepository.GetAllProducts();
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category) => _productRepository.SearchProducts(name, minPrice, maxPrice, category);
=======

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
>>>>>>> origin/tai_cart
    }
}
