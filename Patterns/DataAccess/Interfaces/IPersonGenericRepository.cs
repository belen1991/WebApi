using DataAccess.Generic;
using Entities.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
  public interface IPersonGenericRepository
  {
    IPersonGenericRepository WithContext(
      UnitOfWork unitOfWork);

    Task<long> Create(Person person);
    Task<bool> Update(Person person);
    Task<Person> GetOne(long personId);
    Task<List<Person>> GetMany();
    Task<bool> Delete(long personId);
  }

}
