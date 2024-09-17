using Microsoft.EntityFrameworkCore;
using Backend.Data.Entities;

namespace Backend.Data.Abstractions
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }

}
