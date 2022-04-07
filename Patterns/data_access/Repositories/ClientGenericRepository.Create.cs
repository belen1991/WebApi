using shared.Domain;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository
  {
    public new long Create(Client client)
    {
      var clientCreated = 
        Create(
          entity: client);

      if(clientCreated != null) 
        _unitOfWork.Commit();
      return 
        clientCreated == null ? 0 : 
          clientCreated.ClientId;
    }


  }
}
