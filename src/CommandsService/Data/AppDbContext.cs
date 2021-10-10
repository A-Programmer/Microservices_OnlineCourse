using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Command> Commands { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(c => c.Platform)
                .HasForeignKey(x => x.PlatformId);

            modelBuilder.Entity<Command>()
                .HasOne(x => x.Platform)
                .WithMany(x => x.Commands)
                .HasForeignKey(x => x.PlatformId);
        }
    }
}