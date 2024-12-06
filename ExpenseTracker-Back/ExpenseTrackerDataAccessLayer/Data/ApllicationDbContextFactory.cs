using ExpenseTrackerDataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        // Configure your connection string, or get it from your app settings
        optionsBuilder.UseSqlServer("Server=DESKTOP-Q9BFJQ9\\SQLEXPRESS;Database=ExpenseTrackerDB;Trusted_Connection=true;TrustServerCertificate=True");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
