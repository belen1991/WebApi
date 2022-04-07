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
    public async Task<List<Person>> GetMany()
    {
      var personTable = await GetAsync();

      return
        JsonConvert
          .DeserializeObject<List<Person>>(
            value: JsonConvert.SerializeObject(
                personTable));

    }

  }
}
