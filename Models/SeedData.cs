using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using CrudContainer.Enum;


namespace CrudContainer.Models
{
  public class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new MvcContainerContext(
          serviceProvider.GetRequiredService<DbContextOptions<MvcContainerContext>>()))
      {
        if (!context.Container.Any())
        {
          context.Container.AddRange(
            new Container
            {
              Number = "ABCD1234567",
              Client = "Client A",
              Type = ContainerType._20ft,
              Status = ContainerStatus.FULL,
              Category = ContainerCategory.IMPORT
            },
            new Container
            {
              Number = "ABCD1234568",
              Client = "Client B",
              Type = ContainerType._40ft,
              Status = ContainerStatus.EMPTY,
              Category = ContainerCategory.EXPORT
            }
          );
          context.SaveChanges();
        }

        if (!context.Movement.Any())
        {
          context.Movement.AddRange(
            new Movement
            {
              Type = MovementType.BOARDING,
              StartDate = DateTime.Now,
              EndDate = DateTime.Now.AddDays(1),
              Container = context.Container.Single(c => c.Number == "ABCD1234567")
            }
          );
          context.SaveChanges();
        }
      }
    }
  }
}