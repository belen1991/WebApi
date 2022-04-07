using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Accounts.Models;

namespace use_cases.Accounts.Queries
{
  [ScopedService]
  public interface IGetManyAccounts
  {
    IGetManyAccounts WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<List<DetailAccountModel>, Failure> Execute();
  }
  public class GetManyAccounts : IGetManyAccounts
  {
    readonly IAccountRepository accountRepository;
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public GetManyAccounts(
      IAccountRepository accountRepository,
      IClientRepository clientRepository,
      IPersonRepository personRepository)
    {
      this.accountRepository = accountRepository;
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IGetManyAccounts WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<List<DetailAccountModel>, Failure> Execute()
    {
      var accounts =
        JsonConvert
            .DeserializeObject<List<DetailAccountModel>>(
              JsonConvert.SerializeObject(
                  accountRepository.GetMany()));
      foreach (var account in accounts)
      {
        var client = clientRepository.GetOne(
          clientId: account.ClientId);
        var person = personRepository.GetOne(
          personId: client.PersonId);

        account.Name = person.Name;
        account.DocumentNumber = person.DocumentNumber;
        account.Status = client.Status;
      }

      return accounts;
    }

  }
}
