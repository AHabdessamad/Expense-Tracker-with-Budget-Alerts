using ExpenseTrackerDataAccessLayer.Data;
using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDataAccessLayer.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> AddCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Type = categoryDto.Type,
                Note = categoryDto.Note
            };

            // Add and save the category
            await _dbContext.categories.AddAsync(category);
            try
            {

                await _dbContext.SaveChangesAsync();
            }catch(Exception e)
            {
                Console.WriteLine($"Error Occured while saving : {e.InnerException}");
            }
            return category;
        }

        public async Task<IEnumerable<Category>> GetALlCategories()
        {
            return await _dbContext.categories.Include(e => e.Expenses).ToListAsync();
        }

        public async Task<Category> DeleteCategory(int id)
        {
            var category = await _dbContext.categories.FirstAsync(c => c.Id == id);
            _dbContext.categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }
    }
}
