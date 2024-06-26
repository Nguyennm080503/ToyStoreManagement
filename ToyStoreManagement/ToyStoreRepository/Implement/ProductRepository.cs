﻿using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class ProductRepository : IProductRepository
    {
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
        public bool UpdateQuantity(Product product) => _productDao.Update(product);
        public List<Product> GetAllProductsHome() =>_productDao.GetAllProductsHome();
    }
}
