using DataAccess.Generic;
using Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
  public interface IAccountGenericRepository
  {
    IAccountGenericRepository WithContext(
      UnitOfWork unitOfWork);
    Task<long> Create(Account account);
    Task<bool> Update(Account account);
    Task<Account> GetOne(long accountNumber);
    Task<List<Account>> GetMany();
    Task<bool> Delete(long accountNumber);
  }

}
