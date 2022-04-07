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
    public async Task<List<Client>> GetMany()
    {
      var clientTable = await GetAsync();

      return
        JsonConvert
          .DeserializeObject<List<Client>>(
            value: JsonConvert.SerializeObject(
                clientTable));

    }

  }
}
