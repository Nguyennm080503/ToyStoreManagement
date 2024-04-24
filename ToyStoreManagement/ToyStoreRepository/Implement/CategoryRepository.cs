using BusinessObjects.Models;
using ToyStoreDao;
using ToyStoreRepository.Interface;

namespace ToyStoreRepository.Implement
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly CategoryDao _categoryDao;

		public CategoryRepository()
		{
			_categoryDao = new CategoryDao();
		}
		public IEnumerable<Category> GetAllCategory()
		{
			return _categoryDao.GetAll();
		}
	}
}
