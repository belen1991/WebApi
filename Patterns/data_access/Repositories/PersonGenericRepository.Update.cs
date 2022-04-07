using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public new bool Update(Person person)
    {
      var updated = 
        Update(
          entity: person);

      if (updated)
        _unitOfWork.Commit();

      return updated;
    }

  }
}
