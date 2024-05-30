using course_backend_entities;
using Microsoft.EntityFrameworkCore;

namespace course_backend_data_access;

public class MyDbContext : DbContext
{
    public DbSet<Gender> Genders { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Empty by the moment
    }
}
