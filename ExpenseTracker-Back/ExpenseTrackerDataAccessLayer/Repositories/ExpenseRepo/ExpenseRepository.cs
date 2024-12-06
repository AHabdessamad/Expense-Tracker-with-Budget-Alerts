using ExpenseTrackerDataAccessLayer.Data;
using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpenseTrackerDataAccessLayer.Repositories.ExpenseRepo
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Expense> AddExpense(Expense expense)
        {
            await _dbContext.expenses.AddAsync(expense);
            try
            {

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Occured while saving : {e.InnerException}");
            }
            
            return expense;

        }
        public async Task<Expense> DeleteExpense(Guid id)
        {
            var expense = await _dbContext.expenses.FirstOrDefaultAsync(e => e.Id == id);
            _dbContext.expenses.Remove(expense);
            _dbContext.SaveChanges();
            return expense;
        }

        public async Task<IEnumerable<Expense>> GetALlExpense()
        {
            return await _dbContext.expenses.ToListAsync();
        }

       
    }
}
