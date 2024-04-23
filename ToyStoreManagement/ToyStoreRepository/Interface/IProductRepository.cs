using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProduct();
    }
}
