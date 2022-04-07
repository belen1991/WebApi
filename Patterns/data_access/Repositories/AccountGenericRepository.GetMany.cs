using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository
  {
    public List<IAccountTableRow> GetMany()
    {
      return
        JsonConvert
          .DeserializeObject<List<AccountTableRow>>(
            value: JsonConvert.SerializeObject(
                GetAll())).ToList<IAccountTableRow>();
    }
  }
}
