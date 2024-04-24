using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDao _feedbackDao;

        public FeedbackRepository()
        {
            _feedbackDao = new FeedbackDao();
        }

        public IEnumerable<Feedback> GetAllFeedback()
        {
            return _feedbackDao.GetAllFeedback();
        }
        public bool CreateFeedback(Feedback feedback)
        {
            return _feedbackDao.Create(feedback);
        }
        public bool UpdateFeedback(Feedback feedback)
        {
            return _feedbackDao.Update(feedback);
        }
        public Feedback GetFeedbackById(int id)
        {
            return _feedbackDao.GetFeedbackById(id);
        }
        public bool DeleteFeedback(int id)
        {
            return _feedbackDao.Delete(id);
        }
        public IEnumerable<Feedback> GetFeedbackByCustomerId(int customerId)
        {
            return _feedbackDao.GetAll().Where(f => f.CustomerId == customerId).ToList();
        }
        public IEnumerable<Feedback> GetFeedbackByProductId(int productId)
        {
            return _feedbackDao.GetAll().Where(f => f.ProductId == productId).ToList();
        }
    }
}
