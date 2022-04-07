using Entities.Domain;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public async Task<long> Create(Client client)
    {
      var clientCreated = 
        await CreateTAsync(
          entity: client);

      return 
        clientCreated == null ? 0 : 
          clientCreated.ClientId;
    }


  }
}
