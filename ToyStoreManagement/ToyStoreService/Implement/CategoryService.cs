﻿using ToyStoreRepository.Interface;
using ToyStoreService.Interface;

namespace ToyStoreService.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) { _categoryRepository = categoryRepository; }
    }
}
