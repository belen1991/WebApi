using Entities.Domain;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public async Task<long> Create(Movement movement)
    {
      var clientCreated = 
        await CreateTAsync(
          entity: movement);

      return 
        clientCreated == null ? 
          0 : 
          clientCreated.MovementId;
    }


  }
}
