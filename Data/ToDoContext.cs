using ToDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToDo.Data
{
    public class ToDoContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options)  // Correct: calling base constructor
        {
        }

        public DbSet<ToDoTask> Tasks { get; set; }   // Property for ToDoTask, outside constructor

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensure Identity configurations are applied

            // Fluent API to configure the relationship between ToDoTask and ApplicationUser
            modelBuilder.Entity<ToDoTask>()
                .HasOne(t => t.User)               // Task has one User
                .WithMany()                         // User can have many Tasks
                .HasForeignKey(t => t.UserId)      // Foreign key on UserId in ToDoTask
                .OnDelete(DeleteBehavior.Cascade); // Optional: you can set behavior if user is deleted
        }
    }
}
