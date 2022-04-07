using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Domain
{
  public class Account
  {
    public long AccountNumber { get; set; }
    public string AccountType { get; set; }
    public double AccountInitialBalance { get; set; }
    public bool AccountStatus { get; set; }
    public long CliientId { get; set; }
  }
}
