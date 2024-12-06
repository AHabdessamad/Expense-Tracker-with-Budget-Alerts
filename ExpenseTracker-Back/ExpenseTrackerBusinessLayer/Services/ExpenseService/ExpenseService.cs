using ExpenseTrackerDataAccessLayer.Entities;
using ExpenseTrackerDataAccessLayer.Repositories.ExpenseRepo;
using SharedDtos;

namespace ExpenseTrackerBusinessLayer.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        public readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }
        public async Task<Expense> AddExpense(ExpenseDto expenseDto)
        {
            var expense = new Expense { Name=expenseDto.Name, Balance = expenseDto.Balance, CategoryId = expenseDto.CategoryId, CreatedAt = DateTime.Now };
            return await _expenseRepository.AddExpense(expense);

        }

        public async Task<Expense> DeleteExpense(Guid id)
        {
            return await _expenseRepository.DeleteExpense(id);
        }

        public async Task<IEnumerable<Expense>> GetAllExpense()
        {
            return await _expenseRepository.GetALlExpense();
        }
    }
}
