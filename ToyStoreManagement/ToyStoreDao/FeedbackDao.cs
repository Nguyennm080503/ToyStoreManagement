using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;


namespace ToyStoreDao
{
    public class FeedbackDao : BaseToyStoreDao<Feedback>
    {
        private readonly ToyStoreDBContext _dbContext;
        public FeedbackDao() { _dbContext = new ToyStoreDBContext(); }

        public IEnumerable<Feedback> GetAllFeedback()
        {
            return _dbContext.Feedbacks.Include(f => f.Customer).Include(f => f.Product).ToList();
        }
        public Feedback GetFeedbackById(int id)
        {
            return _dbContext.Feedbacks.Include(f => f.Customer).Include(f => f.Product).FirstOrDefault(f => f.FeedbackId == id);
        }
    }
}
