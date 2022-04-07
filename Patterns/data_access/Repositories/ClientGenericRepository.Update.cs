using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public new bool Update(Client client)
    {
      var updated = Update(
          entity: client);

      if (updated)
        _unitOfWork.Commit();

      return updated;
    }

  }
}
