using Microsoft.EntityFrameworkCore;

namespace Study.LabWork3;

public class UniversityDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=university.db");
    }
}
