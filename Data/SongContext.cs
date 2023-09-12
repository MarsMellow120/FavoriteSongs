using Microsoft.EntityFrameworkCore;
using FavoriteSongs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FavoriteSongs.Data
{
    public class SongContext : IdentityDbContext<User>
    {
        public SongContext(DbContextOptions<SongContext> options) : base(options)
        { }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(
    new Genre { GenreId = "RP", GenreName = "Rap" },
    new Genre { GenreId = "RK", GenreName = "Rock" },
    new Genre { GenreId = "CY", GenreName = "Country" },
    new Genre { GenreId = "JZ", GenreName = "Jazz" }
    );
            modelBuilder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    title = "Clouds",
                    artist = "NF",
                    cost = 0.99,
                    yearRecorded = 2021,
                    GenreId = "RP"
                },
                new Song
                {
                    Id = 2,
                    title = "Son of a sinner",
                    artist = "Jelly Roll",
                    cost = 0.99,
                    yearRecorded = 2022,
                    GenreId = "RK"
                },
                new Song
                {
                    Id = 3,
                    title = "Replay",
                    artist = "Iyaz",
                    cost = 0.99,
                    yearRecorded = 2009,
                    GenreId = "RP"
                },
                new Song
                {
                    Id = 4,
                    title = "Heart like a truck",
                    artist = "Lainey Wilson",
                    cost = 0.99,
                    yearRecorded = 2022,
                    GenreId = "CY"
                }
                );
        }
    }
}
