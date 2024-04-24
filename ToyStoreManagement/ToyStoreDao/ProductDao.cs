<<<<<<< HEAD
﻿
using BusinessObjects.Models;
=======
﻿using BusinessObjects.Models;
>>>>>>> main
using Microsoft.EntityFrameworkCore;


namespace ToyStoreDao
{
    public class ProductDao : BaseToyStoreDao<Product>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductDao() { _dbContext = new ToyStoreDBContext(); }

        public void AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
<<<<<<< HEAD
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = GetProductById(updatedProduct.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.StockQuantity = updatedProduct.StockQuantity;
                existingProduct.PhotoUrlThumnail = updatedProduct.PhotoUrlThumnail;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                existingProduct.Status = updatedProduct.Status;

                _dbContext.Products.Attach(existingProduct);
                _dbContext.Entry(existingProduct).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
        }
        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.Include(c => c.Category).ToList();
        }
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category)
        {
            var query = _dbContext.Products.AsQueryable();

            // Filter by name
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            // Filter by price range
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            }

            // Filter by category
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category != null && p.Category.Name == category);
            }

            return query.ToList();
=======
>>>>>>> main
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var existingProduct = GetProductById(updatedProduct.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.StockQuantity = updatedProduct.StockQuantity;
                existingProduct.PhotoUrlThumnail = updatedProduct.PhotoUrlThumnail;
                existingProduct.CategoryId = updatedProduct.CategoryId;
                existingProduct.Status = updatedProduct.Status;

                _dbContext.Products.Attach(existingProduct);
                _dbContext.Entry(existingProduct).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);
            if (productToDelete != null)
            {
                _dbContext.Products.Remove(productToDelete);
                _dbContext.SaveChanges();
            }
        }
        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.Include(c => c.Category).ToList();
        }
        public List<Product> SearchProducts(string? name, decimal? minPrice, decimal? maxPrice, string? category)
        {
            var query = _dbContext.Products.AsQueryable();

            // Filter by name
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            // Filter by price range
            if (minPrice.HasValue && maxPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice && p.Price <= maxPrice);
            }

            // Filter by category
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category != null && p.Category.Name == category);
            }

            return query.ToList();
        }        
    }
}
