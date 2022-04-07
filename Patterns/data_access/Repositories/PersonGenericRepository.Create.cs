
using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository
  {
    public new long Create(Person person)
    {
      var personCreated = 
        Create(
          entity: person);

      if (personCreated != null)
        _unitOfWork.Commit();

      return 
        personCreated == null ? 0 : 
          personCreated.PersonId;
    }


  }
}
