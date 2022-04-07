using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace use_cases.Accounts.Models
{
  public class AccountModel
  {
    public long AccountNumber { get; set; }
    public string AccountType { get; set; }
    public double AccountInitialBalance { get; set; }
    public bool AccountStatus { get; set; }
    public long ClientId { get; set; }
  }
}
