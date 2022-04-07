using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Shared;
using System;
using System.Collections.Generic;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Clients.Models;
using use_cases.Movements.Models;

namespace use_cases.Movements.Queries
{
  [ScopedService]
  public interface IGetMovementsReport
  {
    IGetMovementsReport WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<List<DetailMovementModel>, Failure> Execute(string documentNumber, DateTime dateTime);
  }
  public class GetMovementsReport: IGetMovementsReport
  {
    readonly IMovementRepository movementRepository;
    readonly IAccountRepository accountRepository;
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public GetMovementsReport(
      IMovementRepository movementRepository,
      IAccountRepository accountRepository,
      IClientRepository clientRepository,
      IPersonRepository personRepository)
    {
      this.accountRepository = accountRepository;
      this.movementRepository = movementRepository;
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IGetMovementsReport WithContext(IUnitOfWork unitOfWork)
    {
      accountRepository.WithContext(unitOfWork);
      movementRepository.WithContext(unitOfWork);
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<List<DetailMovementModel>, Failure> Execute(string documentNumber, DateTime dateTime)
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

      var accountsModel = accountRepository.GetManyByClient(
          clientId: clientModel.ClientId);

      if (accountsModel == null || accountsModel.Count <= 0)
        return new NoResult();

      List<DetailMovementModel> detailMovements = new();
      foreach (var account in accountsModel)
      {
          var movementsModel = movementRepository.GetManyByDate(
              accountNumber: account.AccountNumber,
              date: DateTime.Now);
          detailMovements.AddRange(
            JsonConvert
            .DeserializeObject<List<DetailMovementModel>>(
              JsonConvert.SerializeObject(
                  movementsModel))
          );
          detailMovements.ForEach(m => {
            m.Name = personModel.Name;
            m.DocumentNumber = personModel.DocumentNumber;
            m.Status = clientModel.Status;
            m.AccountInitialBalance = account.AccountInitialBalance;
            m.AccountType = account.AccountType;
          });
      }

      return detailMovements;
    }

  }
}
