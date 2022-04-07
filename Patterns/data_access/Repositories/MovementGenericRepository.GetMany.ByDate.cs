
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public List<IMovementTableRow> GetManyByDate(long accountNumber, DateTime date)
    {
      var movementTable = GetMany(m => 
        m.AccountNumber == accountNumber &&
        m.MovementDate.Date == date.Date && 
        m.MovementDate.Month == date.Month &&
        m.MovementDate.Year == date.Year);

      return
        JsonConvert
          .DeserializeObject<List<MovementTableRow>>(
            value: JsonConvert.SerializeObject(
                movementTable)).ToList<IMovementTableRow>();

    }

  }
}
