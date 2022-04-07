using shared.DatabaseContext;
using shared.Domain;
using DataAccess.Generic;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository : GenericRepository<Client>, IClientRepository
  {
    public IClientRepository WithContext(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    public class ClientTableRow : IClientTableRow
    {
      public long ClientId { get; set; }
      public long PersonId { get; set; }
      public string Password { get; set; }
      public bool Status { get; set; }
    }
  }
}
