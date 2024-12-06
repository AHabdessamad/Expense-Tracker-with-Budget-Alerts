using ExpenseTrackerDataAccessLayer.Entities;
using SharedDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDataAccessLayer.Repositories.ExpenseRepo
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Expense>> GetALlExpense();
        public Task<Expense> AddExpense(Expense expense);
        public Task<Expense> DeleteExpense(Guid id);

    }
}
