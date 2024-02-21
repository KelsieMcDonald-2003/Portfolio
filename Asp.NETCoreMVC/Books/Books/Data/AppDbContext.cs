using Books.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<GenreModel> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<GenreModel>().HasData(
                    new GenreModel { GenreId = "A", GenreName = "Action"},
                    new GenreModel { GenreId = "C", GenreName = "Comedy" },
                    new GenreModel { GenreId = "D", GenreName = "Drama" },
                    new GenreModel { GenreId = "F", GenreName = "Fantasy" },
                    new GenreModel { GenreId = "H", GenreName = "Horror" },
                    new GenreModel { GenreId = "M", GenreName = "Musical" },
                    new GenreModel { GenreId = "R", GenreName = "RomCom" },
                    new GenreModel { GenreId = "S", GenreName = "SciFi" },
                    new GenreModel { GenreId = "SF", GenreName = "SciFi-Fantasy"}
                );
            modelbuilder.Entity<BookModel>().HasData(
                    new BookModel
                    {
                        BookId = 1,
                        Title = "Leven Thumps",
                        Author = "Obert Skye",
                        PubYear = 2011,
                        Description = "A young boy and girl save the magical realm.",
                        Rating = 5,
                        GenreId = "SF"
                    }
                );
        }
    }
}