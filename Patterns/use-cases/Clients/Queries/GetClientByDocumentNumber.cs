using Newtonsoft.Json;
using shared.DatabaseContext;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;
using use_cases.Clients.Models;

namespace use_cases.Clients.Queries
{
  [ScopedService]
  public interface IGetClientByDocumentNumber
  {
    IGetClientByDocumentNumber WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<ClientModel, Failure> Execute(string documentNumber);
  }
  public class GetClientByDocumentNumber: IGetClientByDocumentNumber
  {
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public GetClientByDocumentNumber(IClientRepository clientRepository, IPersonRepository personRepository)
    {
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IGetClientByDocumentNumber WithContext(IUnitOfWork unitOfWork)
    {
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }

    public UseCaseResult<ClientModel, Failure> Execute(string documentNumber)
    {
      var personModel = JsonConvert
            .DeserializeObject<PersonModel>(
              JsonConvert.SerializeObject(
                  personRepository.GetOneByDocumentNumber(
                    documentNumber: documentNumber)));

      if (personModel == null)
        return new UseCaseError() { reason = new { ClientNotFounded = true } };

      var clientModel = JsonConvert
            .DeserializeObject<ClientModel>(
              JsonConvert.SerializeObject(
                  clientRepository.GetOneByPersonId(personId: personModel.PersonId)));

      if (clientModel == null)
        return new UseCaseError() { reason = new { ClientNotFounded = true } };

      clientModel.SetPersonModel(personModel: personModel);
      return clientModel;

    }

  }
}
