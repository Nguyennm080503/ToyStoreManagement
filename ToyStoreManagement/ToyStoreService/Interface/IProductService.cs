using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IProductService
    {
        public void AddProduct(Product product);
        public Product GetProductById(int productId);
        public void UpdateProduct(Product updatedProduct);
        public void DeleteProduct(int productId);
        public List<Product> GetAllProducts();
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category);
        bool UpdateQuantity(Product product);
    }
}
