using Newtonsoft.Json;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public  IPersonTableRow GetOne(long personId)
    {
      var personTable = GetOne(
          whereCondition: a => a.PersonId == personId);

      return
        JsonConvert
          .DeserializeObject<PersonTableRow>(
            JsonConvert.SerializeObject(
                personTable));

    }

  }
}
