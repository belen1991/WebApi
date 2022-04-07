using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public new long Create(Movement movement)
    {
      var movementCreated =
        Create(
          entity: movement);

      if (movementCreated != null)
        _unitOfWork.Commit();

      return
        movementCreated == null ? 0 :
          movementCreated.AccountNumber;
    }
  }
}
