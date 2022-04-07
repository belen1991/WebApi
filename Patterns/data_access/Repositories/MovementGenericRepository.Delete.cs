
namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository
  {
    public bool Delete(long movementId)
    {
      var movementEntity =
        GetOne(
          whereCondition: a => a.MovementId == movementId);

      var movementRemoved = Remove(
          entity: movementEntity);

      if (movementRemoved)
        _unitOfWork.Commit();

      return movementRemoved;

    }

  }
}
