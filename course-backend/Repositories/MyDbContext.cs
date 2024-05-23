using course_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace course_backend.Repositories;

public class MyDbContext : DbContext
{
    public DbSet<Gender> Genders { get; set; }

    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
    }
}
