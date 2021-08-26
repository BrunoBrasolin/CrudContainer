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
              Status = ContainerStatus.Cheio,
              Category = ContainerCategory.Importação
            },
            new Container
            {
              Number = "ABCD1234568",
              Client = "Client B",
              Type = ContainerType._40ft,
              Status = ContainerStatus.Vazio,
              Category = ContainerCategory.Exportação
            }
          );
          context.SaveChanges();
        }

        if (!context.Movement.Any())
        {
          context.Movement.AddRange(
            new Movement
            {
              Type = 0,
              StartDate = DateTime.Now,
              EndDate = DateTime.Now.AddDays(1),
              Container = context.Container.First(),
            }
          );
          context.SaveChanges();
        }
      }
    }
  }
}