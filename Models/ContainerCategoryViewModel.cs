using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CrudContainer.Enum;

namespace CrudContainer.Models
{
  public class ContainerCategoryViewModel
  {
    public List<Container> Containers { get; set; }
    public SelectList Categories { get; set; }
    public ContainerCategory ContainerCategory { get; set; }
    public string SearchString { get; set; }
  }
}