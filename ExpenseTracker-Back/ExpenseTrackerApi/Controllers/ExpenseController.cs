using ExpenseTrackerBusinessLayer.Services.ExpenseService;
using ExpenseTrackerBusinessLogicLayer.Results;
using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedDtos;

namespace ExpenseTrackerApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ExpenseController : Controller
    {
        public readonly IExpenseService _expenseTrackerService;
        public ExpenseController(IExpenseService expenseTrackerService)
        {
            _expenseTrackerService = expenseTrackerService;
        }
        [HttpGet]
        public async Task<ActionResult<Response<IEnumerable<Expense>>>> GetAllExpense()
        {
            try
            {
                var bodgets = await _expenseTrackerService.GetAllExpense();

                if (bodgets == null || !bodgets.Any())
                {
                    return Response<IEnumerable<Expense>>.Failure(404, "No Expenses found");
                }

                return Response<IEnumerable<Expense>>.Success(200, "Expenses retrieved successfully", bodgets);
            }
            catch (Exception ex)
            {
                return Response<IEnumerable<Expense>>.Failure(500, $"Server error {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Response<Expense>>> AddExpense(ExpenseDto expenseDto)
        {
            try
            {
                var createdExpense = await  _expenseTrackerService.AddExpense(expenseDto);
                if (createdExpense == null)
                {
                    return Response<Expense>.Failure(404, "Failed to create book");
                }

                return Response<Expense>.Success(201, "Expense Created Successfully", createdExpense);

            }
            catch (Exception ex)
            {
                return Response<Expense>.Failure(500, $"Error from server {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Response<Expense>>> DeleteExpense(Guid id)
        {

            try
            {
                var deletionResult = await _expenseTrackerService.DeleteExpense(id);

                if (deletionResult == null)
                {
                    return Response<Expense>.Failure(404, $"Expense with id {id} not found");
                }

                return Response<Expense>.Success(200, "Expense deleted successfully", deletionResult);
            }
            catch (Exception ex)
            {
                return Response<Expense>.Failure(500, $"Server error: {ex.Message}");
            }

        }
    }
}
