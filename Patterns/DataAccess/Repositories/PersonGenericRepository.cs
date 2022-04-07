using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class PersonGenericRepository : GenericRepository<Person>, IPersonGenericRepository
  {
    public IPersonGenericRepository WithContext(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    //public class PersonTableRow : IPersonTableRow
    //{
    //  public long PersonId { get; set; }
    //  public string Name { get; set; }
    //  public string Gender { get; set; }
    //  public string Age { get; set; }
    //  public string DocumentNumber { get; set; }
    //  public string Address { get; set; }
    //  public string Phone { get; set; }
    //}
  }
}
