
using Newtonsoft.Json;
using shared.Domain;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public IAccountTableRow GetOne(long accountNumber)
    {
      var accountTable = GetOne(
          whereCondition: a => a.AccountNumber == accountNumber);

      return
        JsonConvert
          .DeserializeObject<AccountTableRow>(
            JsonConvert.SerializeObject(
                accountTable));

    }

  }
}
