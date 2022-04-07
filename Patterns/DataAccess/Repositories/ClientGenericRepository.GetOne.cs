using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public async Task<Client> GetOne(long clientId)
    {
      var clientTable = await GetAsync(
          whereCondition: a => a.ClientId == clientId);

      return
        JsonConvert
          .DeserializeObject<Client>(
            JsonConvert.SerializeObject(
                clientTable));

    }

  }
}
