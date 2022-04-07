using System;

namespace use_cases.Movements.Models
{
  public class MovementModel
  {
    public long MovementId { get; set; }
    public DateTime MovementDate { get; set; }
    public double MovementValue { get; set; }
    public double MovementBalance { get; set; }
    public string MovementType { get; set; }
    public long AccountNumber { get; set; }
  }
}
