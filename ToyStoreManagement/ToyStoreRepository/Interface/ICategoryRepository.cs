using BusinessObjects.Models;

namespace ToyStoreRepository.Interface
{
    public interface ICategoryRepository
    {
		IEnumerable<Category> GetAllCategory();
    }
}
