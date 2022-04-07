
namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public bool Delete(long personId)
    {
      var personEntity = 
        GetOne(
          whereCondition: a => a.PersonId == personId);

      var removed =
        Remove(
          entity: personEntity);

      if (removed)
        _unitOfWork.Commit();

      return removed;
    }

  }
}
