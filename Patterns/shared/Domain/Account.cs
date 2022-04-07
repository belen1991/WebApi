using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace shared.Domain
{
  public class Account
  {
    [Key]
    public long AccountNumber { get; set; }
    public string AccountType { get; set; }
    public double AccountInitialBalance { get; set; }
    public bool AccountStatus { get; set; }
    public long ClientId { get; set; }
  }
}
