using ExpenseTrackerDataAccessLayer.Entities;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDataAccessLayer.Repositories.CategoryRepo
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetALlCategories();
        public Task<Category> AddCategory(CategoryDto categoryDto);
        public Task<Category> DeleteCategory(int id);
    }
}
