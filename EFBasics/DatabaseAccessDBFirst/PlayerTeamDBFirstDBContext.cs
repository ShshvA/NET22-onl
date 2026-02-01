using System;
using System.Collections.Generic;
using DatabaseAccessDBFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccessDBFirst;

public class PlayerTeamDBFirstDBContext : DbContext
{
    public PlayerTeamDBFirstDBContext()
    {
    }

    public PlayerTeamDBFirstDBContext(DbContextOptions<PlayerTeamDBFirstDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Coach> Coaches { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=DatabaseCodeFirst;Persist Security Info=True;User ID=artem;Password=artem1234;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Application Name=\"SQL Server Management Studio\";Command Timeout=0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasIndex(e => e.TeamId, "IX_Players_TeamId");

            entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Team).WithMany(p => p.Players).HasForeignKey(d => d.TeamId);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasIndex(e => e.CoachId, "IX_Teams_CoachId");

            entity.HasOne(d => d.Coach).WithMany(p => p.Teams).HasForeignKey(d => d.CoachId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    public void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {}
}
