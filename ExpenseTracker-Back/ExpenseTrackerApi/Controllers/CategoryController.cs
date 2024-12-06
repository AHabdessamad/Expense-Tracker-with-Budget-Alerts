using ExpenseTrackerBusinessLayer.Services.CategoryService;
using ExpenseTrackerBusinessLogicLayer.Results;
using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using SharedDtos;

namespace ExpenseTrackerApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
        public readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
            _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<IEnumerable<Category>>>> GetAllExpense()
    {
        try
        {
            var categories = await _categoryService.GetALlCategories();

            if (categories == null || !categories.Any())
            {
                return Response<IEnumerable<Category>>.Failure(404, "No Categories found");
            }

            return Response<IEnumerable<Category>>.Success(200, "Categories fetched successfully", categories);
        }
        catch (Exception ex)
        {
            return Response<IEnumerable<Category>>.Failure(500, $"Server error {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<Response<Category>>> AddExpense(CategoryDto categoryDto)
    {
        try
        {
            var createdCategory = await _categoryService.AddCategory(categoryDto);
            if (createdCategory == null)
            {
                return Response<Category>.Failure(404, "Failed to create Category");
            }

            return Response<Category>.Success(201, "Category Created Successfully", createdCategory);

        }
        catch (Exception ex)
        {
            return Response<Category>.Failure(500, $"Error from server {ex.Message}");
        }
    }

    }
}
