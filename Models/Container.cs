using System;
using System.ComponentModel.DataAnnotations;

namespace CrudContainer.Models
{
  public class Container {
    public int Id { get; set; }
    public string Number { get; set; }
    public string Client { get; set; }
    public int Type { get; set; }
    public int Status { get; set; }
    public int Category { get; set; }
  }
}