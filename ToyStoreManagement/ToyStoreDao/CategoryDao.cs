

using BusinessObjects.Models;

namespace ToyStoreDao
{
    public class CategoryDao : BaseToyStoreDao<Category>
    {
        private readonly ToyStoreDBContext _dbContext;
        public CategoryDao(ToyStoreDBContext dBContext) { _dbContext = dBContext; }
    }
}
