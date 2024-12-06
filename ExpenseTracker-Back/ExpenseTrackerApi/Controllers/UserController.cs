using ExpenseTrackerDataAccessLayer.Data;
using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApi.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CheckMonthlyBudgetExceeded(Guid userId)
        {
            var totalExpenses = _dbContext.expenses
                .Where(e => e.CreatedAt.Month == DateTime.Now.Month && e.CreatedAt.Year == DateTime.Now.Year && e.UserId == userId)
                .Sum(e => e.Balance);

            var userBudget = _dbContext.bodgets
                .FirstOrDefault(b => b.UserId == userId && b.Date.Month == DateTime.Now.Month && b.Date.Year == DateTime.Now.Year);

            // 3. Check if the total expenses exceed the budget
            if (userBudget != null && totalExpenses > userBudget.Balance)
            {
                NotifyUser(userId, totalExpenses, userBudget.Balance);
            }
        }

        private void NotifyUser(Guid userId, double totalExpenses, double budgetAmount)
        {
            var message = $"Your total expenses of {totalExpenses:C} have exceeded your monthly budget of {budgetAmount:C}.";

            SendEmailNotification(userId, message);
        }

        public void SendEmailNotification(Guid userId, string message)
        {
            
        }

        //public async Task<ActionResult<User>> GetUserData(Guid id)
        //{
        //    var user = await _dbContext.users.FirstOrDefaultAsync(u => u.Id == id);
        //    return Task<ActionResult<User>>;

        //}
    }
}
