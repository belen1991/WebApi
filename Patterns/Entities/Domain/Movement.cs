using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Domain
{
  public class Movement
  {
    public long MovementId { get; set; }
    public DateTime MovementDate { get; set; }
    public double MovementValue { get; set; }
    public double MovementBalance { get; set; }
    public long AccountNumber { get; set; }
  }
}
