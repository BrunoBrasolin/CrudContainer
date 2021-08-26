using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using CrudContainer.Enum;

namespace CrudContainer.Models
{
  public class Container
  {
    public int Id { get; set; }

    [StringLength(11)]
    [Required]
    [RegularExpression("^[A-Z]{4}[0-9]{7}$")]
    public string Number { get; set; }

    [StringLength(255)]
    [Required]
    public string Client { get; set; }

    [Range(0, 1)]
    [Required]
    public ContainerType Type { get; set; }

    [Range(0, 1)]
    [Required]
    public ContainerStatus Status { get; set; }

    [Range(0, 1)]
    [Required]
    public ContainerCategory Category { get; set; }

    public ICollection<Movement> Movements { get; set; }
  }
}