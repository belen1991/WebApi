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
  public partial class PersonGenericRepository
  {
    public async Task<Person> GetOne(long personId)
    {
      var personTable = await GetAsync(
          whereCondition: a => a.PersonId == personId);

      return
        JsonConvert
          .DeserializeObject<Person>(
            JsonConvert.SerializeObject(
                personTable));

    }

  }
}
