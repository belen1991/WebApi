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
using use_cases.Clients.Models;

namespace use_cases.Accounts.Queries
{
  [ScopedService]
  public interface IGetAccountByClient
  {
    IGetAccountByClient WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<List<DetailAccountModel>, Failure> Execute(string documentNumber);
  }
  public class GetAccountsByClient : IGetAccountByClient
  {
    readonly IAccountRepository accountRepository;
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public GetAccountsByClient(
      IAccountRepository accountRepository,
      IClientRepository clientRepository,
      IPersonRepository personRepository)
    {
      this.accountRepository = accountRepository;
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IGetAccountByClient WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<List<DetailAccountModel>, Failure> Execute(string documentNumber)
    {
      var personModel = JsonConvert
            .DeserializeObject<PersonModel>(
              JsonConvert.SerializeObject(
                  personRepository.GetOneByDocumentNumber(
                    documentNumber: documentNumber)));

      if (personModel == null || personModel.PersonId <= 0)
        return new NoResult();

      var clientModel = JsonConvert
            .DeserializeObject<ClientModel>(
              JsonConvert.SerializeObject(
                  clientRepository.GetOneByPersonId(personId: personModel.PersonId)));

      if (clientModel == null || clientModel.PersonId <= 0)
        return new NoResult();

      var accounts =
        JsonConvert
            .DeserializeObject<List<DetailAccountModel>>(
              JsonConvert.SerializeObject(
                  accountRepository.GetManyByClient(clientId:
                    clientModel.ClientId
                    )));
      accounts.ForEach(a => {
        a.Name = personModel.Name;
        a.DocumentNumber = personModel.DocumentNumber;
        a.Status = clientModel.Status;
      });

      return accounts;
    }

  }
}
