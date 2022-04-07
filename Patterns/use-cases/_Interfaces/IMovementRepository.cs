using shared.DatabaseContext;
using shared.Domain;
using System;
using System.Collections.Generic;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace use_cases._Interfaces
{
  [ScopedService]
  public interface IMovementRepository
  {
    IMovementRepository WithContext(
      IUnitOfWork unitOfWork);
    long Create(Movement movement);
    bool Update(Movement movement);
    IMovementTableRow GetOne(long movementId);
    List<IMovementTableRow> GetMany();
    List<IMovementTableRow> GetManyByAccount(long accountNumber);
    List<IMovementTableRow> GetManyByDate(long accountNumber, DateTime date);
    IMovementTableRow GetLastMovement(long accountNumber);
    bool Delete(long movementId);
  }

  public interface IMovementTableRow
  {
    long MovementId { get; set; }
    DateTime MovementDate { get; set; }
    double MovementValue { get; set; }
    double MovementBalance { get; set; }
    string MovementType { get; set; }
    long AccountNumber { get; set; }
  }
}
