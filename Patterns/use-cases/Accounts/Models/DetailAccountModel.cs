
namespace use_cases.Accounts.Models
{
  public class DetailAccountModel: AccountModel
  {
    public string Name { get; set; }
    public string DocumentNumber { get; set; }
    public bool Status { get; set; }
  }
}
