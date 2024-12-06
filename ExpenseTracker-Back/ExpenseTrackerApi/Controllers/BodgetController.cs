using ExpenseTrackerBusinessLayer.Services.BodgetService;
using ExpenseTrackerBusinessLayer.Services.CategoryService;
using ExpenseTrackerBusinessLogicLayer.Results;
using ExpenseTrackerDataAccessLayer.Entities;
using ExpenseTrackerDataAccessLayer.Repositories.BodgetRepo;
using Microsoft.AspNetCore.Mvc;
using SharedDtos;

namespace ExpenseTrackerApi.Controllers
{

        [ApiController]
        [Route("/api/[controller]")]
        public class BodgetController : Controller
        {
            private readonly IBodgetService _bodgetService;
            public BodgetController(IBodgetService bodegtService)
            {
                _bodgetService = bodegtService;
            }

            //[HttpGet]
            //public ActionResult<Response<IEnumerable<Bodget>>> GetBodetByMonth()
            //{
            //    try
            //    {
            //        var expenses = _categoryService.GetALlCategories();

            //        if (expenses == null || !expenses.Any())
            //        {
            //            return Response<IEnumerable<Category>>.Failure(404, "No Expenses found");
            //        }

            //        return Response<IEnumerable<Category>>.Success(200, "Expenses retrieved successfully", expenses);
            //    }
            //    catch (Exception ex)
            //    {
            //        return Response<IEnumerable<Category>>.Failure(500, $"Server error {ex.Message}");
            //    }
            //}

            [HttpPost]
            public async Task<ActionResult<Response<Bodget>>> AddBodeget(BodgetDto bodgetDto)
            {
                try
                {
                    var createdBodget = await _bodgetService.AddBodget(bodgetDto);
                    if (createdBodget == null)
                    {
                        return Response<Bodget>.Failure(404, "Failed to create new Bodget");
                    }

                    return Response<Bodget>.Success(201, "Bodget Created Successfully", createdBodget);

                }
                catch (Exception ex)
                {
                    return Response<Bodget>.Failure(500, $"Error from server {ex.Message}");
                }
            }

        [HttpPut("{id}")]
        public async Task<ActionResult<Response<Bodget>>> UpdateBodegt(Guid id, BodgetDto bodgetDto)
        {
            try
            {
                if (bodgetDto == null)
                {
                    return Response<Bodget>.Failure(400, "Invalid book data");
                }

                var updatedBodget = await _bodgetService.UpdateBodget(id, bodgetDto);

                if (updatedBodget == null)
                {
                    return Response<Bodget>.Failure(401, $"Book with id {id} not found");
                }

                return Response<Bodget>.Success(200, "Book updated successfully", updatedBodget);
            }
            catch (Exception ex)
            {
                return Response<Bodget>.Failure(500, $"Server Error: {ex.Message}");
            }
        }

        }
    }
