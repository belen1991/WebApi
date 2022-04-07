
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public List<IPersonTableRow> GetMany()
    {
      var personTable = GetAll();

      return
        JsonConvert
          .DeserializeObject<List<PersonTableRow>>(
            value: JsonConvert.SerializeObject(
                personTable)).ToList<IPersonTableRow>();

    }

  }
}
