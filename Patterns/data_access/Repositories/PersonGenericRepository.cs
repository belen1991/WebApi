using DataAccess.Generic;
using use_cases._Interfaces;
using shared.Domain;
using shared.DatabaseContext;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository : GenericRepository<Person>, IPersonRepository
  {
    public IPersonRepository WithContext(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    public class PersonTableRow : IPersonTableRow
    {
      public long PersonId { get; set; }
      public string Name { get; set; }
      public string Gender { get; set; }
      public string Age { get; set; }
      public string DocumentNumber { get; set; }
      public string Address { get; set; }
      public string Phone { get; set; }
    }
  }
}
