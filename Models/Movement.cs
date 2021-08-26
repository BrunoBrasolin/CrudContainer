using System;
using System.ComponentModel.DataAnnotations;

namespace CrudContainer.Models
{
  public class Movement
  {
    public int Id { get; set; }

    [Range(0, 6)]
    [Required]
    public int Type { get; set; }

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