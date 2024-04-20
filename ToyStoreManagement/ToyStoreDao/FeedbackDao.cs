using BusinessObjects.Models;


namespace ToyStoreDao
{
    public class FeedbackDao : BaseToyStoreDao<Feedback>
    {
        private readonly ToyStoreDBContext _dbContext;
        public FeedbackDao() { _dbContext = new ToyStoreDBContext(); }
    }
}
