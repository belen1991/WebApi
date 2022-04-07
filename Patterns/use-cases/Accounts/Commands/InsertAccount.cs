using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Domain;
using shared.Shared;
using System;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Accounts.Models;
using use_cases.Clients.Models;
using use_cases.Movements.Models;

namespace use_cases.Accounts.Commands
{
  [ScopedService]
  public interface IInsertAccount
  {
    IInsertAccount WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<AccountModel, Failure> Execute(AccountModel account, string documentNumber);
  }

  public class InsertAccount : IInsertAccount
  {
    readonly IAccountRepository accountRepository;
    readonly IMovementRepository movementRepository;
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public InsertAccount(
      IAccountRepository accountRepository,
      IClientRepository clientRepository,
      IMovementRepository movementRepository,
      IPersonRepository personRepository)
    {
      this.accountRepository = accountRepository;
      this.movementRepository = movementRepository;
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IInsertAccount WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      clientRepository.WithContext(unitOfWork);
      movementRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<AccountModel, Failure> Execute(AccountModel account, string documentNumber)
    {
      var accountFounded = 
        accountRepository.GetOne(
          accountNumber: account.AccountNumber);

      if(accountFounded!=null)
        return new UseCaseError() { reason = new { AccountNumberAlredyExist = true } };

      if (account.AccountInitialBalance < 0)
        return new UseCaseError() { reason = new { InitialBalanceMustBePositive = true } };

      var personModel = personRepository.
                GetOneByDocumentNumber(
                    documentNumber: documentNumber);

      if (personModel == null || personModel.PersonId <=0)
        return new NoResult();

      var clientModel = clientRepository.
                GetOneByPersonId(
                    personId: personModel.PersonId);

      if (clientModel == null || clientModel.PersonId <= 0)
        return new NoResult();

      account.ClientId = clientModel.ClientId;
      var accountCreated = 
        accountRepository.Create(
          account: JsonConvert
              .DeserializeObject<Account>(
                JsonConvert.SerializeObject(
                    account)));

      if (accountCreated == null)
        return new UseCaseError() { reason = new { AccountNoCreated = true } };

      var movementModel = new MovementModel
      {
        AccountNumber = accountCreated.AccountNumber,
        MovementDate = DateTime.Now,
        MovementValue = account.AccountInitialBalance,
        MovementBalance = 0,
        MovementType = "Credito"
      };

      movementRepository.Create(
        movement: JsonConvert
              .DeserializeObject<Movement>(
                JsonConvert.SerializeObject(
                    movementModel)));

      return JsonConvert
              .DeserializeObject<AccountModel>(
                JsonConvert.SerializeObject(
                  accountCreated));
      
    }

  }
}
