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

            // Seeding games
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 1,
                Title = "Red Dead Redemption",
                Summary = "* Red Dead Redemption",
                NewlyReleases = false,
                Trailer = "",
                ReleaseDate = new DateTime(2011, 10, 26),
                Poster = "Images/Game/RedDeadRedemption.jpg"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 2,
                Title = "Red Dead Redemption 2",
                Summary = "* Red Dead Redemption 2",
                NewlyReleases = true,
                Trailer = "SXvQ1nK4oxk",
                ReleaseDate = new DateTime(2018, 10, 26),
                Poster = "Images/Game/RedDeadRedemption-2.jpg"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 3,
                Title = "Little Nightmares",
                Summary = "* Little Nightmares",
                NewlyReleases = false,
                Trailer = "aOadxZBsPiA",
                ReleaseDate = new DateTime(2017, 02, 26),
                Poster = "Images/Game/LittleNightmares-1.jpg"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 4,
                Title = "Little Nightmares 2",
                Summary = "* Little Nightmares 2",
                NewlyReleases = true,
                Trailer = "AI9zBBTyX-E",
                ReleaseDate = new DateTime(2021, 02, 26),
                Poster = "Images/Game/LittleNightmares-2.jpg"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 5,
                Title = "Assassins Creed - Odyssey",
                Summary = "* Assassins Creed - Odyssey",
                NewlyReleases = false,
                Trailer = "s_SJZSAtLBA",
                ReleaseDate = new DateTime(2018, 12, 10),
                Poster = "Images/Game/AssassinsCreed-Odyssey.jpg"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 6,
                Title = "Assassins Creed - Valhalla",
                Summary = "* Assassins Creed - Valhalla",
                NewlyReleases = true,
                Trailer = "z-r2AhqxBzw",
                ReleaseDate = new DateTime(2021, 02, 26),
                Poster = "Images/Game/AssassinsCreed-Valhalla.jpg"
            });
            modelBuilder.Entity<Game>().HasData(new Game
            {
                Id = 7,
                Title = "The Witcher 3 - Wild Hunt",
                Summary = "* The Witcher 3 - Wild Hunt",
                NewlyReleases = false,
                Trailer = "c0i88t0Kacs",
                ReleaseDate = new DateTime(2050, 02, 26),
                Poster = "Images/Game/TheWitcher-WildHunt.jpg"
            });

            // Seeding genres
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 1,
                Name = "Horror"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 2,
                Name = "Thriller"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 3,
                Name = "Fantasy"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 4,
                Name = "Norse Mythology"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 5,
                Name = "Acient Greek"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 6,
                Name = "Western"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 7,
                Name = "Action"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 8,
                Name = "Platform"
            });
            modelBuilder.Entity<Genre>().HasData(new Genre
            {
                Id = 9,
                Name = "RPG"
            });

            //Seeding people
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 1,
                Name = "Ulrik Rosberg",
                Biography = "* Ulrik Rosberg",
                Picture = "Images/Person/UlrikRosberg.jpg",
                DateOfBirth = new DateTime(1993, 10, 22)
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 2,
                Name = "Anna Moberg",
                Biography = "* Anna Moberg",
                Picture = "Images/Person/AnnaMoberg.jpg",
                DateOfBirth = new DateTime(1998, 05, 22)
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 3,
                Name = "Magnus Bruun",
                Biography = "* Magnus Bruun",
                Picture = "Images/Person/MagnusBruun.jpg",
                DateOfBirth = new DateTime(1993, 10, 22)
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 4,
                Name = "Michael Antonakos",
                Biography = "* Michael Antanakos",
                Picture = "Images/Person/MichaelAntonakos.jpg",
                DateOfBirth = new DateTime(1980, 10, 22)
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 5,
                Name = "Roger Clark",
                Biography = "* Roger Clark",
                Picture = "Images/Person/RogerClark.jpg",
                DateOfBirth = new DateTime(1978, 10, 22)
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 6,
                Name = "Rob Wiethoff",
                Biography = "* Robert Wiethoff",
                Picture = "Images/Person/RobWiethoff.jpg",
                DateOfBirth = new DateTime(1978, 10, 22)
            });
            modelBuilder.Entity<Person>().HasData(new Person
            {
                Id = 7,
                Name = "Doug Cockle",
                Biography = "* Doug Cockle",
                Picture = "Images/Person/DougCockle.jpg",
                DateOfBirth = new DateTime(1978, 10, 22)
            });

            // Seeding games genres
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 3
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 4
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 6,
                GenreId = 9
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 3
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 5
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 5,
                GenreId = 9
            });

            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 3,
                GenreId = 1
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 3,
                GenreId = 2
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 3,
                GenreId = 3
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 3,
                GenreId = 8
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 4,
                GenreId = 1
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 4,
                GenreId = 2
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 4,
                GenreId = 3
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 4,
                GenreId = 8
            });
            //red dead 1 2
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 1,
                GenreId = 6
            });

            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 1,
                GenreId = 7
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 1,
                GenreId = 9
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 2,
                GenreId = 6
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 2,
                GenreId = 7
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 2,
                GenreId = 9
            });

            
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 3
            });
            modelBuilder.Entity<GamesGenres>().HasData(new GamesGenres
            {
                GameId = 7,
                GenreId = 9
            });
            //Seeding people in game
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 1,
                RoleOfGame = "Programmer",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 2,
                RoleOfGame = "Programmer",
                Order = 3
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 3,
                RoleOfGame = "Programmer",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 4,
                RoleOfGame = "Programmer",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 5,
                RoleOfGame = "Programmer",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 6,
                RoleOfGame = "Programmer",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 1,
                GameId = 7,
                RoleOfGame = "Programmer",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 6,
                GameId = 1,
                RoleOfGame = "John Marston",
                Order = 1
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 6,
                GameId = 2,
                RoleOfGame = "John Marston",
                Order = 2
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 5,
                GameId = 2,
                RoleOfGame = "Arthur Morgan",
                Order = 1
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 2,
                GameId = 3,
                RoleOfGame = "Six",
                Order = 1
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 2,
                GameId = 4,
                RoleOfGame = "Six / Mono",
                Order = 1
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 4,
                GameId = 5,
                RoleOfGame = "Alexios",
                Order = 1
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 3,
                GameId = 6,
                RoleOfGame = "Eivor Wolf-Kissed",
                Order = 1
            });
            modelBuilder.Entity<GamesPeople>().HasData(new GamesPeople
            {
                PersonId = 7,
                GameId = 7,
                RoleOfGame = "Geralt of Rivia",
                Order = 1
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