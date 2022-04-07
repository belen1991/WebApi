using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public async Task<bool> Delete(long accountNumber)
    {
      var accountEntity = 
        await GetAsync(
          whereCondition: a => a.AccountNumber == accountNumber);
      return 
        await RemoveAsync(
          entity: accountEntity);
    }

  }
}
