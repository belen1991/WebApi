using System.Collections.Generic;
using shared.DatabaseContext;
using shared.Domain;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace use_cases._Interfaces
{
  [ScopedService]
  public interface IPersonRepository
  {
    IPersonRepository WithContext(
      IUnitOfWork unitOfWork);

    long Create(Person person);
    bool Update(Person person);
    IPersonTableRow GetOne(long personId);
    IPersonTableRow GetOneByDocumentNumber(string documentNumber);
    List<IPersonTableRow> GetMany();
    bool Delete(long personId);
  }

  public interface IPersonTableRow
  {
    long PersonId { get; set; }
    string Name { get; set; }
    string Gender { get; set; }
    string Age { get; set; }
    string DocumentNumber { get; set; }
    string Address { get; set; }
    string Phone { get; set; }
  }
}
