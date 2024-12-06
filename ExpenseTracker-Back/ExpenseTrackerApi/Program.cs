using ExpenseTrackerBusinessLayer.Services.BodgetService;
using ExpenseTrackerBusinessLayer.Services.CategoryService;
using ExpenseTrackerBusinessLayer.Services.ExpenseService;
using ExpenseTrackerDataAccessLayer.Data;
using ExpenseTrackerDataAccessLayer.Repositories.BodgetRepo;
using ExpenseTrackerDataAccessLayer.Repositories.CategoryRepo;
using ExpenseTrackerDataAccessLayer.Repositories.ExpenseRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

builder.Services.AddScoped<IBodgetRepository, BodgetRepository>();
builder.Services.AddScoped<IBodgetService, BodgetService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options.UseSqlServer(
          builder.Configuration.GetConnectionString("DbConnectionString"),
          b => b.MigrationsAssembly("ExpenseTrackerDataAccessLayer")
    )
);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
