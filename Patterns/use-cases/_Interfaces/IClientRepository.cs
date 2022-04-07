using shared.DatabaseContext;
using shared.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace use_cases._Interfaces
{
  [ScopedService]
  public interface IClientRepository
  {
    IClientRepository WithContext(
      IUnitOfWork unitOfWork);

    long Create(Client client);
    bool Update(Client client);
    IClientTableRow GetOne(long clientId);
    IClientTableRow GetOneByPersonId(long personId);
    List<IClientTableRow> GetMany();
    bool Delete(long clientId);
  }

  public interface IClientTableRow
  {
    long ClientId { get; set; }
    long PersonId { get; set; }
    string Password { get; set; }
    bool Status { get; set; }
  }
}
