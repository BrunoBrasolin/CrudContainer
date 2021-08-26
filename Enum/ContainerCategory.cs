using System.ComponentModel.DataAnnotations;


namespace CrudContainer.Enum
{
  public enum ContainerCategory
  {
    [Display(Name = "Importação")]
    IMPORT = 0,

    [Display(Name = "Exportação")]
    EXPORT = 1
  }
}