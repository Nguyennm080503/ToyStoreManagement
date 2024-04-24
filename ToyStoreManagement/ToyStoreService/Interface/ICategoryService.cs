using BusinessObjects.Models;

namespace ToyStoreService.Interface
{
    public interface ICategoryService
    {
		IEnumerable<Category> GetAllCategory();
	}
}
