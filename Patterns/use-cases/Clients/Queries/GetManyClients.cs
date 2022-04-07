using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Shared;
using System.Collections.Generic;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Clients.Models;

namespace use_cases.Clients.Queries
{
  [ScopedService]
  public interface IGetManyClients
  {
    IGetManyClients WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<List<ClientModel>, Failure> Execute();
  }
  public class GetManyClients : IGetManyClients
  {
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public GetManyClients(IClientRepository clientRepository, IPersonRepository personRepository)
    {
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IGetManyClients WithContext(IUnitOfWork unitOfWork)
    {
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<List<ClientModel>, Failure> Execute()
    {
      var clientsModel = JsonConvert
            .DeserializeObject<List<ClientModel>>(
              JsonConvert.SerializeObject(
                  clientRepository.GetMany()));
      foreach (var client in clientsModel)
      {
        var personModel = JsonConvert
            .DeserializeObject<PersonModel>(
              JsonConvert.SerializeObject(
                personRepository.GetOne(personId: client.PersonId)));
        client.SetPersonModel(personModel: personModel);
      }
      
      return clientsModel;
    }

  }
}
