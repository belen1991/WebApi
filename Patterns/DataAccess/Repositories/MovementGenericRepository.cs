using DataAccess.Generic;
using DataAccess.Interfaces;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository : GenericRepository<Movement>, IMovementGenericRepository
  {
    public IMovementGenericRepository WithContext(UnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    //public class MovementTableRow : IMovementTableRow
    //{
    //  public long MovementId { get; set; }
    //  public DateTime MovementDate { get; set; }
    //  public double MovementValue { get; set; }
    //  public double MovementBalance { get; set; }
    //  public long AccountNumber { get; set; }
    //}
  }
}
