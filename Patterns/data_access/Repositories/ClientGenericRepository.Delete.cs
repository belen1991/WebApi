
namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public bool Delete(long clientId)
    {
      var clientEntity = 
        GetOne(
          whereCondition: a => a.ClientId == clientId);

      var deleted =
        Remove(
          entity: clientEntity);

      if (deleted)
        _unitOfWork.Commit();

      return deleted;

    }

  }
}
