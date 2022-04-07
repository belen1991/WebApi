using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Domain
{
  public class Person
  {
    public long PersonId { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Age { get; set; }
    public string DocumentNumber { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
  }
}
