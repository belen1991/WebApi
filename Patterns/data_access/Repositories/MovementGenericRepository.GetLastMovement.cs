
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public IMovementTableRow GetLastMovement(long accountNumber)
    {
      var movementTable = GetMany(m => 
        m.AccountNumber == accountNumber, a => a.OrderBy(b => b.MovementDate)).LastOrDefault();

      return
        JsonConvert
          .DeserializeObject<MovementTableRow>(
            value: JsonConvert.SerializeObject(
                movementTable));

    }

  }
}
