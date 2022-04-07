using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public async Task<bool> Delete(long movementId)
    {
      var movementEntity = 
        await GetAsync(
          whereCondition: a => a.MovementId == movementId);
      return 
        await RemoveAsync(
          entity: movementEntity);
    }

  }
}
