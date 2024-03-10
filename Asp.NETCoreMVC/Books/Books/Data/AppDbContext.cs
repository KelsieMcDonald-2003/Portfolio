using Books.Data;
using Books.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Books.Data
{
    public class AppDbContext : IdentityDbContext<AppUserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<GenreModel> Genres { get; set; }
        public DbSet<StoryModel> Stories { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<CommentsModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GenreModel>().HasData(
                    new GenreModel { GenreId = "A", GenreName = "Action" },
                    new GenreModel { GenreId = "C", GenreName = "Comedy" },
                    new GenreModel { GenreId = "D", GenreName = "Drama" },
                    new GenreModel { GenreId = "F", GenreName = "Fantasy" },
                    new GenreModel { GenreId = "H", GenreName = "Horror" },
                    new GenreModel { GenreId = "MY", GenreName = "Mystery" },
                    new GenreModel { GenreId = "R", GenreName = "RomCom" },
                    new GenreModel { GenreId = "S", GenreName = "SciFi" },
                    new GenreModel { GenreId = "SF", GenreName = "SciFi-Fantasy" }
                );

            builder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            base.OnModelCreating(builder);
        }
    }
}
