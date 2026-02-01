using DatabaseAccessCodeFirst.Configurations;
using DatabaseAccessCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccessCodeFirst
{
    public class PlayerTeamCodeFirstDBContext : DbContext
    {
        public PlayerTeamCodeFirstDBContext(DbContextOptions<PlayerTeamCodeFirstDBContext> options) : base(options)
        {
        }

        public PlayerTeamCodeFirstDBContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }
        public DbSet<CoachEntity> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CoachConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=DatabaseCodeFirst;Persist Security Info=True;User ID=artem;Password=artem1234;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=0");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
