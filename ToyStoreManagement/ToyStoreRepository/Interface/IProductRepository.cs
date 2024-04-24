using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IProductRepository
    {
<<<<<<< HEAD
        public void AddProduct(Product product);
        public Product GetProductById(int productId);
        public void UpdateProduct(Product updatedProduct);
        public void DeleteProduct(int productId);
        public List<Product> GetAllProducts();
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category);
=======
        public IEnumerable<Product> GetAllProduct();
        public Product GetProductById(int id);
        bool UpdateQuantity (Product product);
        
>>>>>>> origin/tai_cart
    }
}
