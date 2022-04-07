using shared.DatabaseContext;
using shared.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace use_cases._Interfaces
{
  [ScopedService]
  public interface IAccountRepository
  {
    IAccountRepository WithContext(
      IUnitOfWork unitOfWork);
    Account Create(Account account);
    bool Update(Account account);
    IAccountTableRow GetOne(long accountNumber);
    List<IAccountTableRow> GetMany();
    List<IAccountTableRow> GetManyByClient(long clientId);
    bool Delete(long accountNumber);
  }

  public interface IAccountTableRow
  {
    long AccountNumber { get; set; }
    string AccountType { get; set; }
    double AccountInitialBalance { get; set; }
    bool AccountStatus { get; set; }
    long ClientId { get; set; }
  }
}
