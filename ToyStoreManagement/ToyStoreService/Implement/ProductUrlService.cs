using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class ProductUrlService : IProductUrlService
    {
        private readonly IProductUrlRepository _productUrlRepository;

        public ProductUrlService(IProductUrlRepository productUrlRepository)
        {
            _productUrlRepository = productUrlRepository;
        }
    }
}
