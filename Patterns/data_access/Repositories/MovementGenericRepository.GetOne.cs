using Newtonsoft.Json;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public IMovementTableRow GetOne(long movementId)
    {
      var movementTable = GetOne(
          whereCondition: a => a.MovementId == movementId);

      return
        JsonConvert
          .DeserializeObject<MovementTableRow>(
            JsonConvert.SerializeObject(
                movementTable));

    }

  }
}
