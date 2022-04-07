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
  public partial class MovementGenericRepository
  {
    public async Task<Movement> GetOne(long movementId)
    {
      var movementTable = await GetAsync(
          whereCondition: a => a.MovementId == movementId);

      return
        JsonConvert
          .DeserializeObject<Movement>(
            JsonConvert.SerializeObject(
                movementTable));

    }

  }
}
