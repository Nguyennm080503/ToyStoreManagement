using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface IFeedbackRepository
    {
        public IEnumerable<Feedback> GetAllFeedback();
        public bool CreateFeedback(Feedback feedback);
        public bool UpdateFeedback(Feedback feedback);
        public bool DeleteFeedback(int id);
        public Feedback GetFeedbackById(int id);
        public IEnumerable<Feedback> GetFeedbackByCustomerId(int customerId);
    }
}
