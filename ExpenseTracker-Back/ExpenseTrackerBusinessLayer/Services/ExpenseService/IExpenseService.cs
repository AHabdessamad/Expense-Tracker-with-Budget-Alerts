using ExpenseTrackerDataAccessLayer.Entities;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerBusinessLayer.Services.ExpenseService
{
    public interface IExpenseService
    {
        public Task<IEnumerable<Expense>> GetAllExpense();
        public Task<Expense> AddExpense(ExpenseDto expenseDto);
        public Task<Expense> DeleteExpense(Guid id);
    }
}
