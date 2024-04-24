using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class ProductRepository : IProductRepository
    {
<<<<<<< HEAD
        private readonly ProductDao _productDao;
        public ProductRepository()
        {
            _productDao = new ProductDao();
        }
        public void AddProduct(Product product) => _productDao.AddProduct(product);
        public Product GetProductById(int productId) => _productDao.GetProductById(productId);
        public void UpdateProduct(Product updatedProduct) => _productDao.UpdateProduct(updatedProduct);
        public void DeleteProduct(int productId) => _productDao.DeleteProduct(productId);
        public List<Product> GetAllProducts() => _productDao.GetAllProducts();
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category) => _productDao.SearchProducts(name, minPrice, maxPrice, category);
=======
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
>>>>>>> origin/tai_cart
    }
}
