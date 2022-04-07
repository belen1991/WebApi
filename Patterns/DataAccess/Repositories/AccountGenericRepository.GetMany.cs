using Entities.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public async Task<List<Account>> GetMany()
    {
      var accountTable = await GetAsync();

      return
        JsonConvert
          .DeserializeObject<List<Account>>(
            value: JsonConvert.SerializeObject(
                accountTable));

    }

  }
}
