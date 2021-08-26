using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudContainer.Models;

public class MvcContainerContext : DbContext
{
  public MvcContainerContext(DbContextOptions<MvcContainerContext> options)
      : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Container>()
        .HasMany<Movement>(s => s.Movements)
        .WithOne(g => g.Container)
        .OnDelete(DeleteBehavior.Cascade);
  }

  public DbSet<CrudContainer.Models.Container> Container { get; set; }
  public DbSet<CrudContainer.Models.Movement> Movement { get; set; }
}
