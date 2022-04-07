using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Domain;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Clients.Models;

namespace use_cases.Clients.Commands
{
  [ScopedService]
  public interface IUpdateClientAsPerson
  {
    IUpdateClientAsPerson WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<bool, Failure> Execute(long clientId, ClientModel client);
  }

  public class UpdateClientAsPerson : IUpdateClientAsPerson
  {
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public UpdateClientAsPerson(IClientRepository clientRepository, IPersonRepository personRepository)
    {
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }
    public IUpdateClientAsPerson WithContext(IUnitOfWork unitOfWork)
    {
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }
    public UseCaseResult<bool, Failure> Execute(long clientId, ClientModel client)
    {
      var clientModel = JsonConvert
            .DeserializeObject<Client>(
              JsonConvert.SerializeObject(
                  clientRepository.GetOne(clientId: clientId)));

      if (clientModel == null)
        return new NoResult();

      var personObject = JsonConvert
              .DeserializeObject<Person>(
                JsonConvert.SerializeObject(
                    client));
      personObject.PersonId = clientModel.PersonId;

      var updatedPerson =
        personRepository.Update(
          person: personObject);

      if (!updatedPerson)
        return new UseCaseError() { reason = new { ClientNoUpdated = true } };

      var clientObject = JsonConvert
              .DeserializeObject<Client>(
                JsonConvert.SerializeObject(
                    client));
      clientObject.ClientId = clientId;
      clientObject.PersonId = clientModel.PersonId;

      return
        clientRepository.Update(
          client: clientObject);
    }

  }
}
