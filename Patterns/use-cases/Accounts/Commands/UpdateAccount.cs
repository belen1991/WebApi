using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Domain;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Accounts.Models;

namespace use_cases.Accounts.Commands
{
  [ScopedService]
  public interface IUpdateAccount
  {
    IUpdateAccount WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<bool, Failure> Execute(AccountModel account);
  }

  public class UpdateAccount : IUpdateAccount
  {
    readonly IAccountRepository accountRepository;

    public UpdateAccount(IAccountRepository accountRepository)
    {
      this.accountRepository = accountRepository;
    }

    public IUpdateAccount WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<bool, Failure> Execute(AccountModel account)
    {
      return accountRepository.Update(
        account: JsonConvert
              .DeserializeObject<Account>(
                JsonConvert.SerializeObject(
                    account)));
    }

  }
}
