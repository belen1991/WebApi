using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Clients.Models;

namespace use_cases.Clients.Queries
{
  [ScopedService]
  public interface IGetClientById
  {
    IGetClientById WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<ClientModel, Failure> Execute(long clientId);
  }
  public class GetClientById : IGetClientById
  {
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public GetClientById(IClientRepository clientRepository, IPersonRepository personRepository)
    {
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IGetClientById WithContext(IUnitOfWork unitOfWork)
    {
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<ClientModel, Failure> Execute(long clientId)
    {
      var clientModel = JsonConvert
            .DeserializeObject<ClientModel>(
              JsonConvert.SerializeObject(
                  clientRepository.GetOne(clientId: clientId)));

      if (clientModel == null)
        return new UseCaseError() { reason = new { ClientNotFounded = true } };

      var personModel = JsonConvert
            .DeserializeObject<PersonModel>(
              JsonConvert.SerializeObject(
                personRepository.GetOne(personId: clientModel.PersonId)));

      if (personModel == null)
        return new UseCaseError() { reason = new { ClientNotFounded = true } };

      clientModel.SetPersonModel(personModel: personModel);
      return clientModel;
    }

  }
}
