using Microsoft.EntityFrameworkCore;
using StudentsDatabase.Entities;

namespace StudentsDatabase.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

    }
}
