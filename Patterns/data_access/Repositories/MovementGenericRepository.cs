using DataAccess.Generic;
using shared.DatabaseContext;
using shared.Domain;
using System;
using use_cases._Interfaces;

namespace DataAccess.Repositories
{
  public partial class MovementGenericRepository : GenericRepository<Movement>, IMovementRepository
  {
    public IMovementRepository WithContext(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
      return this;
    }

    public class MovementTableRow : IMovementTableRow
    {
      public long MovementId { get; set; }
      public DateTime MovementDate { get; set; }
      public double MovementValue { get; set; }
      public double MovementBalance { get; set; }
      public string MovementType { get; set; }
      public long AccountNumber { get; set; }
    }
  }
}
