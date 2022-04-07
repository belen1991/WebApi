using DataAccess.Generic;
using shared.DatabaseContext;
using shared.Domain;
using System.Collections.Generic;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class AccountGenericRepository : GenericRepository<Account>, IAccountRepository
  {
    public IAccountRepository WithContext(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    public class AccountTableRow : IAccountTableRow
    {
      public long AccountNumber { get; set; }
      public string AccountType { get; set; }
      public double AccountInitialBalance { get; set; }
      public bool AccountStatus { get; set; }
      public long ClientId { get; set; }
    }
  }
}
