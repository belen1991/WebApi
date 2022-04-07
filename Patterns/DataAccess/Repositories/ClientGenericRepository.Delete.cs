using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public async Task<bool> Delete(long clientId)
    {
      var clientEntity = 
        await GetAsync(
          whereCondition: a => a.ClientId == clientId);
      return 
        await RemoveAsync(
          entity: clientEntity);
    }

  }
}
