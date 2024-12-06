using ExpenseTrackerDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Category> categories { get; set; } 
        public DbSet<Bodget> bodgets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Expenses)
                .WithOne(e => e.Category)
                .HasForeignKey("CategoryId")
                .IsRequired();

            modelBuilder.Entity<Bodget>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bodgets)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<User>()
               .HasMany(e => e.Expense)
               .WithOne(e => e.User)
               .HasForeignKey("UserId")
               .IsRequired();
        }
    }
}
