using System;
using System.Collections.Generic;
using AutoMapper;
using ComputerStore.Services.Interfaces;
using ComputerStore.Services.DTOs;
using ComputerStore.Data.Entities;
using ComputerStore.Data.Interfaces;

namespace ComputerStore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryDTO AddCategory(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _categoryRepository.Add(categoryEntity);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public bool DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _categoryRepository.Delete(category);
        }

        public IEnumerable<CategoryDTO> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public CategoryDTO UpdateCategory(CategoryDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _categoryRepository.Update(categoryEntity);
            return category;
        }
    }
}
