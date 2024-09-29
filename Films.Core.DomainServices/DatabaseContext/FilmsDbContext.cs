﻿using Films.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Films.Core.DomainServices.DatabaseContext
{
    public class FilmsDbContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public FilmsDbContext(DbContextOptions<FilmsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Empty by the moment
        }
    }
}
