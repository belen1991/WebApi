using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public async Task<bool> Delete(long personId)
    {
      var personEntity = 
        await GetAsync(
          whereCondition: a => a.PersonId == personId);
      return 
        await RemoveAsync(
          entity: personEntity);
    }

  }
}
