using Newtonsoft.Json;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public IClientTableRow GetOne(long clientId)
    {
      var clientTable = GetOne(
          whereCondition: a => a.ClientId == clientId);

      return
        JsonConvert
          .DeserializeObject<ClientTableRow>(
            JsonConvert.SerializeObject(
               value: clientTable));

    }

  }
}
