using DataAccess.Generic;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
  public interface IMovementGenericRepository
  {
    IMovementGenericRepository WithContext(
      UnitOfWork unitOfWork);
    Task<long> Create(Movement movement);
    Task<bool> Update(Movement movement);
    Task<Movement> GetOne(long movementId);
    Task<List<Movement>> GetMany();
    Task<bool> Delete(long movementId);
  }

}
