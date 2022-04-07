using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository : GenericRepository<Account>, IAccountGenericRepository
  {
    public IAccountGenericRepository WithContext(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    //public class AccountTableRow : IAccountTableRow
    //{
    //  public long AccountNumber { get; set; }
    //  public string AccountType { get; set; }
    //  public double AccountInitialBalance { get; set; }
    //  public bool AccountStatus { get; set; }
    //  public long CliientId { get; set; }
    //}
  }
}
