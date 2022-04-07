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
    public async Task<List<Movement>> GetMany()
    {
      var movementTable = await GetAsync();

      return
        JsonConvert
          .DeserializeObject<List<Movement>>(
            value: JsonConvert.SerializeObject(
                movementTable));

    }

  }
}
