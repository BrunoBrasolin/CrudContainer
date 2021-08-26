using System.ComponentModel.DataAnnotations;


namespace CrudContainer.Enum
{
  public enum ContainerCategory
  {
    [Display(Name = "Todas")]
    ALL,
    [Display(Name = "Importação")]
    IMPORT,

    [Display(Name = "Exportação")]
    EXPORT
  }
}