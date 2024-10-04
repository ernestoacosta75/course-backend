using Films.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Films.Core.DomainServices.DatabaseContext
{
    public class FilmsDbContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmsActors> FilmsActors { get; set; }
        public DbSet<FilmsGenders> FilmsGenders { get; set; }
        public DbSet<FilmsCinemas> FilmsCinemas { get; set; }

        public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmsActors>()
                .HasKey(k => new { k.ActorId, k.FilmId });

            modelBuilder.Entity<FilmsGenders>()
                .HasKey(k => new { k.FilmId, k.GenderId });

            modelBuilder.Entity<FilmsCinemas>()
                .HasKey(k => new { k.FilmId, k.CinemaId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
