using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProduct();
    }
}
