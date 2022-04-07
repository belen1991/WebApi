using Entities.Domain;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public async Task<long> Create(Account account)
    {
      var accountCreated = 
        await CreateTAsync(
          entity: account);

      return 
        accountCreated == null ? 0 : 
          accountCreated.AccountNumber;
    }


  }
}
