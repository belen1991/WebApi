
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public List<IMovementTableRow> GetManyByAccount(long accountNumber)
    {
      var movementTable = GetMany(m => 
            m.AccountNumber == accountNumber);

      return
        JsonConvert
          .DeserializeObject<List<MovementTableRow>>(
            value: JsonConvert.SerializeObject(
                movementTable)).ToList<IMovementTableRow>();

    }

  }
}
