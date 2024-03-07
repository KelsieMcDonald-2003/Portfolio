using Crochet.Data;
using Crochet.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Crochet.Data
{
    public class AppDbContext : IdentityDbContext<AppUserModel>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<HooksModel> Hooks { get; set; }
        public DbSet<LevelsModel> Levels { get; set; }
        public DbSet<PatternsModel> Patterns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HooksModel>().HasData(
                    new HooksModel { HookId = "A", HookName = "B-1", HookSize = "2.25mm"},
                    new HooksModel { HookId = "B", HookName = "C-2", HookSize = "2.75mm" },
                    new HooksModel { HookId = "C", HookName = "D-3", HookSize = "3.25mm" },
                    new HooksModel { HookId = "D", HookName = "E-4", HookSize = "3.50mm" },
                    new HooksModel { HookId = "E", HookName = "F-5", HookSize = "3.75mm" },
                    new HooksModel { HookId = "F", HookName = "G-6", HookSize = "4.00mm" },
                    new HooksModel { HookId = "G", HookName = "7", HookSize = "4.50mm" },
                    new HooksModel { HookId = "H", HookName = "H-8", HookSize = "5.00mm" },
                    new HooksModel { HookId = "I", HookName = "I-9", HookSize = "5.50mm" },
                    new HooksModel { HookId = "J", HookName = "J-10", HookSize = "6.00mm" },
                    new HooksModel { HookId = "K", HookName = "K-10.5", HookSize = "6.50mm" },
                    new HooksModel { HookId = "L", HookName = "L-11", HookSize = "8.00mm" },
                    new HooksModel { HookId = "M", HookName = "M/N-13", HookSize = "9.00mm" },
                    new HooksModel { HookId = "N", HookName = "N/P-15", HookSize = "10.00mm" },
                    new HooksModel { HookId = "O", HookName = "P/Q", HookSize = "15.00mm" },
                    new HooksModel { HookId = "P", HookName = "Q", HookSize = "16.00mm" },
                    new HooksModel { HookId = "Q", HookName = "S", HookSize = "19.00mm" },
                    new HooksModel { HookId = "R", HookName = "T", HookSize = "25.00mm" }
                );
            modelBuilder.Entity<LevelsModel>().HasData(
                    new LevelsModel { LevelId = "A", Level = "Beginner"},
                    new LevelsModel { LevelId = "B", Level = "Easy" },
                    new LevelsModel { LevelId = "C", Level = "Intermediate" },
                    new LevelsModel { LevelId = "D", Level = "Advanced" },
                    new LevelsModel { LevelId = "E", Level = "Expert" }
            );

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            base.OnModelCreating(modelBuilder);
        }
    }
}