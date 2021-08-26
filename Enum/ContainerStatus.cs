using System.ComponentModel.DataAnnotations;

namespace CrudContainer.Enum
{
  public enum ContainerStatus
  {
    [Display(Name = "Cheio")]
    FULL,
    [Display(Name = "Vazio")]
    EMPTY
  }
}