using gamecenter.Shared.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace gamecenter.Server.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamesGenres>().HasKey(x => new { x.GameId, x.GenreId});
            modelBuilder.Entity<GamesPeople>().HasKey(x => new { x.GameId, x.PersonId});

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 1,
                Title = "Red Dead Redemption 2",
                Summary = "* Red Dead Redemption 2",
                NewlyReleases = true,
                Trailer = "SXvQ1nK4oxk",
                ReleaseDate = new DateTime(2018, 10, 26),
                Poster = "Images"

            });
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<GamesPeople> GamesPeople { get; set; }
        public DbSet<GamesGenres> GamesGenres { get; set; }
        public DbSet<GameRating> GameRatings { get; set; }
    }
}