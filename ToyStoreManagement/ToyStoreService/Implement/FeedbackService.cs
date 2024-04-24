using BusinessObjects.Models;
using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public bool CreateFeedback(Feedback feedback)
        {
            return _feedbackRepository.CreateFeedback(feedback);
        }

        public bool DeleteFeedback(int id)
        {
            return _feedbackRepository.DeleteFeedback(id);
        }

        public IEnumerable<Feedback> GetAllFeedback()
        {
            return _feedbackRepository.GetAllFeedback();
        }

        public IEnumerable<Feedback> GetFeedbackByCustomerId(int customerId)
        {
            return _feedbackRepository.GetFeedbackByCustomerId(customerId);
        }

        public Feedback GetFeedbackById(int id)
        {
            return _feedbackRepository.GetFeedbackById(id);
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            return _feedbackRepository.UpdateFeedback(feedback);
        }
    }
}
