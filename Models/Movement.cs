using System;
using System.ComponentModel.DataAnnotations;
using CrudContainer.Enum;

namespace CrudContainer.Models
{
  public class Movement
  {
    public int Id { get; set; }

    [Required]
    public MovementType Type { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }

    [Required]
    public Container Container { get; set; }
  }
}