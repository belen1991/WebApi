using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public List<IClientTableRow> GetMany()
    {
      var clientTable = GetAll();

      return
        JsonConvert
          .DeserializeObject<List<ClientTableRow>>(value:
            JsonConvert.SerializeObject(
                value: clientTable)).ToList<IClientTableRow>();
    }

  }
}
