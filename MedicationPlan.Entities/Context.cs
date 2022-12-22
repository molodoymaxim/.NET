using MedicationPlan.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MedicationPlan.Entities;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Pacient> Pacients { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>().HasKey(x => x.Id);
        modelBuilder.Entity<Medicament>().HasKey(x => x.Id);
        modelBuilder.Entity<Note>().HasKey(x => x.Id);
        modelBuilder.Entity<Pacient>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().HasKey(x => x.Id);

        modelBuilder.Entity<Medicament>()
            .HasMany(x => x.Notes)
            .WithOne(x => x.Medicament)
            .HasForeignKey(x => x.MedicamentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Pacient>()
            .HasMany(x => x.Notes)
            .WithOne(x => x.Pacient)
            .HasForeignKey(x => x.PacientId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Pacient>()
            .HasOne(x => x.User)
            .WithMany(x => x.Pacients)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
            .HasMany(x => x.Doctors)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Doctor>()
            .HasMany(x => x.Notes)
            .WithOne(x => x.Doctor)
            .HasForeignKey(x => x.Doctorid)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}