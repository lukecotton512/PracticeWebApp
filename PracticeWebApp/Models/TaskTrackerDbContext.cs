using System;
using Microsoft.EntityFrameworkCore;

namespace PracticeWebApp.Models
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options) {
            
        }
        public DbSet<Task> Tasks { get; set; }

    }
}
