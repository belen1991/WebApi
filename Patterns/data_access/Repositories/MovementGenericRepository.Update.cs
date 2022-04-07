using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public new bool Update(Movement movement)
    {
      var movementUpdated =
         Update(
          entity: movement);

      if (movementUpdated)
        _unitOfWork.Commit();

      return movementUpdated;

    }

  }
}
