using Newtonsoft.Json;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public IPersonTableRow GetOneByDocumentNumber(string documentNumber)
    {
      var personTable = GetOne(
          whereCondition: a => a.DocumentNumber == documentNumber);

      return
        JsonConvert
          .DeserializeObject<PersonTableRow>(
            JsonConvert.SerializeObject(
                personTable));

    }

  }
}
