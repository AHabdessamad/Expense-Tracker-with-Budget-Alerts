using ExpenseTrackerDataAccessLayer.Entities;
using ExpenseTrackerDataAccessLayer.Repositories.CategoryRepo;
using ExpenseTrackerDataAccessLayer.Repositories.ExpenseRepo;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerBusinessLayer.Services.CategoryService
{

    public class CategoryService  : ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> GetALlCategories()
        {
            return await _categoryRepository.GetALlCategories();
        }
        public async Task<Category> AddCategory(CategoryDto categoryDto)
        {
            return await _categoryRepository.AddCategory(categoryDto);
        }
        public  async Task<Category> DeleteCategory(int id)
        {
            return await _categoryRepository.DeleteCategory(id);
        }


    }
}
