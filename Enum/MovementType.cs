using System.ComponentModel.DataAnnotations;
using CrudContainer.Enum;

namespace CrudContainer.Enum
{
  public enum MovementType
  {
    [Display(Name = "Embarque")]
    BOARDING,
    [Display(Name = "Descarga")]
    LANDING,
    [Display(Name = "Gate In")]
    GATE_IN,
    [Display(Name = "Gate out")]
    GATE_OUT,
    [Display(Name = "Posicionamento Pilha")]
    STACK_POSITION,
    [Display(Name = "Pesagem")]
    WEIGHING,
    [Display(Name = "Scanner")]
    SCANNER
  }
}