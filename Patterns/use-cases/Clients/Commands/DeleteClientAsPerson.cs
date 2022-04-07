using shared.DatabaseContext;
using shared.Shared;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using use_cases._Interfaces;

namespace use_cases.Clients.Commands
{
  [ScopedService]
  public interface IDeleteClientAsPerson
  {
    IDeleteClientAsPerson WithContext(IUnitOfWork unitOfWork);

    UseCaseResult<bool, Failure> Execute(long clientId);
  }

  public class DeleteClientAsPerson : IDeleteClientAsPerson
  {
    readonly IClientRepository clientRepository;
    readonly IPersonRepository personRepository;

    public DeleteClientAsPerson(IClientRepository clientRepository, IPersonRepository personRepository)
    {
      this.clientRepository = clientRepository;
      this.personRepository = personRepository;
    }

    public IDeleteClientAsPerson WithContext(IUnitOfWork unitOfWork)
    {
      clientRepository.WithContext(unitOfWork);
      personRepository.WithContext(unitOfWork);
      return this;
    }
    public UseCaseResult<bool, Failure> Execute(long clientId)
    {
      var clientTable = clientRepository.GetOne(clientId);
      var deletedPerson =
        personRepository.Delete(
          personId: clientTable.PersonId);

      if (deletedPerson)
        return new UseCaseError() { reason = new { ClientNoDeleted = true } };

      return
        clientRepository.Delete(
          clientId: clientId);
    }

  }
}
