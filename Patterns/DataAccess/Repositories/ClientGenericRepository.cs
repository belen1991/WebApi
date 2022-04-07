using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class ClientGenericRepository : GenericRepository<Client>, IClientGenericRepository
  {
    public IClientGenericRepository WithContext(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    //public class ClientTableRow : IClientTableRow
    //{
    //  public long ClientId { get; set; }
    //  public long PersonId { get; set; }
    //  public string Password { get; set; }
    //  public string Status { get; set; }
    //}
  }
}
