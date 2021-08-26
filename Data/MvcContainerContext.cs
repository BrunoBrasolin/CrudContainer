using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudContainer.Models;
using CrudContainer.Enum;

public class MvcContainerContext : DbContext
{
  public MvcContainerContext(DbContextOptions<MvcContainerContext> options)
      : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder
        .Entity<Container>()
        .HasMany<Movement>(s => s.Movements)
        .WithOne(g => g.Container)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder
        .Entity<Container>()
        .Property(e => e.Type)
        .HasConversion(
          v => v.ToString(),
          v => (ContainerType)Enum.Parse(typeof(ContainerType), v));

    modelBuilder
        .Entity<Container>()
        .Property(e => e.Status)
        .HasConversion(
          v => v.ToString(),
          v => (ContainerStatus)Enum.Parse(typeof(ContainerStatus), v));

    modelBuilder
        .Entity<Container>()
        .Property(e => e.Category)
        .HasConversion(
          v => v.ToString(),
          v => (ContainerCategory)Enum.Parse(typeof(ContainerCategory), v));
  }

  public DbSet<CrudContainer.Models.Container> Container { get; set; }
  public DbSet<CrudContainer.Models.Movement> Movement { get; set; }
}
