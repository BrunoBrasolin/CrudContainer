using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CrudContainer.Models
{
    public class SeedData
    {
      public static void Initialize(IServiceProvider serviceProvider)
      {
        using (var context = new MvcContainerContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcContainerContext>>()))
            {
              if (context.Container.Any())
              {
                return;
              }

              context.Container.AddRange(
                new Container
                {
                  Number = "ABCD1234567",
                  Client = "Client A",
                  Type = 1,
                  Status = 1,
                  Category = 1
                },
                new Container
                {
                  Number = "ABCD1234568",
                  Client = "Client B",
                  Type = 0,
                  Status = 0,
                  Category = 0
                }
              );
              context.SaveChanges();
            }
      }
    }
}