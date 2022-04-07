using Entities.Domain;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public async Task<long> Create(Person person)
    {
      var personCreated = 
        await CreateTAsync(
          entity: person);

      return 
        personCreated == null ? 
          0 : 
          personCreated.PersonId;
    }


  }
}
