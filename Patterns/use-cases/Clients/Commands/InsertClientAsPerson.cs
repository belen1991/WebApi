using Newtonsoft.Json;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using shared.DatabaseContext;
using shared.Domain;
using shared.Shared;
using use_cases._Interfaces;
using use_cases.Clients.Models;

namespace use_cases.Clients.Commands
{
  [ScopedService]
  public interface IInsertClientAsPerson
  {
    IInsertClientAsPerson WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<ClientModel, Failure> Execute(ClientModel client);
  }

  public class InsertClientAsPerson : IInsertClientAsPerson
  {
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public InsertClientAsPerson(IClientRepository clientRepository, IPersonRepository personRepository)
    {
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }
    public IInsertClientAsPerson WithContext(IUnitOfWork unitOfWork)
    {
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }
    public UseCaseResult<ClientModel, Failure> Execute(ClientModel client)
    {

      var addedPersonId = 
        personRepository.Create(
          person:
            JsonConvert
              .DeserializeObject<Person>(
                JsonConvert.SerializeObject(
                    client)));

      if (addedPersonId==0)
        return new UseCaseError() { reason = new { ClientNoCreated = true } };

      client.PersonId = addedPersonId;

      var clientRegisteredId =
        clientRepository.Create(
          client:
            JsonConvert
              .DeserializeObject<Client>(
                JsonConvert.SerializeObject(
                    client)));
      client.ClientId = clientRegisteredId;
      return client;
    }

  }
}
