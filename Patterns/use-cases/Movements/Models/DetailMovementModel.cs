using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace use_cases.Movements.Models
{
  public class DetailMovementModel : MovementModel
  {
    public double AccountInitialBalance { get; set; }
    public string AccountType { get; set; }
    public string Name { get; set; }
    public string DocumentNumber { get; set; }
    public bool Status { get; set; }
  }
}
