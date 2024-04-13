

using BusinessObjects.Models;

namespace ToyStoreDao
{
    public class ProductReviewDao : BaseToyStoreDao<ProductReview>
    {
        private readonly ToyStoreDBContext _dbContext;
        public ProductReviewDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }
    }
}
