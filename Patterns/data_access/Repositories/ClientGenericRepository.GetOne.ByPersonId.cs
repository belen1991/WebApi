using Newtonsoft.Json;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public IClientTableRow GetOneByPersonId(long personId)
    {
      var clientTable = GetOne(
          whereCondition: a => a.PersonId == personId);

      return
        JsonConvert
          .DeserializeObject<ClientTableRow>(value:
            JsonConvert.SerializeObject(
               value: clientTable));

    }

  }
}
