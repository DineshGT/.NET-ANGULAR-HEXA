using CodingChallenge1.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge1.Context
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<Models.TaskItem> Tasks { get; set; }
    }
}
