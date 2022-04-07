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
  public interface IDeleteAccount
  {
    IDeleteAccount WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<bool, Failure> Execute(long accountNumber);
  }

  public class DeleteAccount : IDeleteAccount
  {
    readonly IAccountRepository accountRepository;
    readonly IMovementRepository movementRepository;

    public DeleteAccount(
      IAccountRepository accountRepository,
      IMovementRepository movementRepository)
    {
      this.accountRepository = accountRepository;
      this.movementRepository = movementRepository;
    }

    public IDeleteAccount WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      movementRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<bool, Failure> Execute(long accountNumber)
    {
      var accountObject =
        accountRepository.GetOne(
                    accountNumber: accountNumber);

      if (accountObject == null)
        return new NoResult();

      var movements = movementRepository.
          GetManyByAccount(
              accountNumber: accountNumber);

      foreach (var movement in movements)
      {
        movementRepository.Delete(
          movementId: movement.MovementId);
      }

      return accountRepository.Delete(
        accountNumber: accountNumber);
    }

  }
}
