using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Domain
{
  public class Client
  {
    public long ClientId { get; set; }
    public long PersonId { get; set; }
    public string Password { get; set; }
    public string Status { get; set; }
  }
}
